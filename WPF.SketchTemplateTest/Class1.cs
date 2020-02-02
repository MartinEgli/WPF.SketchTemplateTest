// -----------------------------------------------------------------------
//  <copyright file="ResourceUriBuilder.cs" company="Anori Soft">
//      Copyright (c) Anori Soft Martin Egli. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest
{
    #region

    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using WPF.SketchTemplateTest.Annotations;

    #endregion

    public class ResourceUriBuilder
    {
#pragma warning disable S1075 // URIs should not be hardcoded

        /// <summary>
        /// The URI pack application
        /// </summary>
        [NotNull]
        public const string UriPackApplication = @"pack://application:,,,/";

#pragma warning restore S1075 // URIs should not be hardcoded

        /// <summary>
        /// The URI pack siteoforigin
        /// </summary>
        [NotNull]
        public const string UriPackSiteoforigin = @"pack://siteoforigin:,,,";

        /// <summary>
        /// The URI pack component part
        /// </summary>
        [NotNull]
        private const string UriPackComponentPart = @"component/";

        /// <summary>
        /// The URI separator
        /// </summary>
        [NotNull]
        private const string UriSeparator = @";";

        /// <summary>
        /// The URI version prefix
        /// </summary>
        [NotNull]
        private const string UriVersionPrefix = @"v";

        /// <summary>
        /// The assembly
        /// </summary>
        [CanBeNull]
        private string assembly;

        /// <summary>
        /// The authority
        /// </summary>
        [CanBeNull]
        private string authority;

        /// <summary>
        /// The version
        /// </summary>
        [CanBeNull]
        private Version version;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceUriBuilder"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <exception cref="ArgumentNullException">location</exception>
        public ResourceUriBuilder([NotNull] string location)
        {
            this.Location = location ?? throw new ArgumentNullException(nameof(location));
        }

        /// <summary>
        /// Gets or sets the authority.
        /// </summary>
        /// <value>
        /// The authority.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [CanBeNull]
        public string Authority
        {
            get => this.authority;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.AddAuthority(value);
            }
        }

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [CanBeNull]
        public string Assembly
        {
            get => this.assembly;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.AddAssembly(value);
            }
        }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [CanBeNull]
        public Version Version
        {
            get => this.version;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.AddVersion(value);
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [NotNull]
        public string Location { get; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public UriKind Kind { get; set; } = UriKind.RelativeOrAbsolute;

        public Uri Build()
        {
            var uriString = new StringBuilder();
            if (this.authority != null)
            {
                uriString.Append(this.authority);
            }

            if (this.assembly != null)
            {
                uriString.Append(this.assembly).Append(UriSeparator);

                if (this.version != null)
                {
                    uriString.Append(UriVersionPrefix).Append(this.version).Append(UriSeparator);
                }

                uriString.Append(UriPackComponentPart);
            }

            uriString.Append(this.Location);
            return new Uri(uriString.ToString(), this.Kind);
        }

        /// <summary>
        /// Sets the kind.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <returns></returns>
        [NotNull]
        public ResourceUriBuilder SetKind(UriKind kind)
        {
            this.Kind = kind;
            return this;
        }

        /// <summary>
        /// Adds the version.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="PropertyAlreadySetException">Version</exception>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [NotNull]
        public ResourceUriBuilder AddVersion([NotNull] Version value)
        {
            if (this.version != null)
            {
                throw new PropertyAlreadySetException(nameof(this.Version));
            }

            this.version = value ?? throw new ArgumentNullException(nameof(value));
            return this;
        }

        /// <summary>
        /// Adds the version.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="PropertyAlreadySetException">Version</exception>
        [NotNull]
        public ResourceUriBuilder AddVersion([NotNull] string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (this.version != null)
            {
                throw new PropertyAlreadySetException(nameof(this.Version));
            }

            if (value.First() == 'v')
            {
                value = value.Remove(0, 1);
            }

            return this.AddVersion(new Version(value));
        }

        /// <summary>
        /// Adds the assembly.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="PropertyAlreadySetException">Assembly</exception>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [NotNull]
        public ResourceUriBuilder AddAssembly([NotNull] string value)
        {
            if (this.assembly != null)
            {
                throw new PropertyAlreadySetException(nameof(this.Assembly));
            }

            this.assembly = value ?? throw new ArgumentNullException(nameof(value));
            return this;
        }

        /// <summary>
        /// Adds the authority.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="PropertyAlreadySetException">Authority</exception>
        /// <exception cref="System.ArgumentNullException">value</exception>
        [NotNull]
        public ResourceUriBuilder AddAuthority([NotNull] string value)
        {
            if (this.authority != null)
            {
                throw new PropertyAlreadySetException(nameof(this.Authority));
            }

            this.authority = value ?? throw new ArgumentNullException(nameof(value));
            return this;
        }

        public ResourceUriBuilder AddAssembly(Assembly executingAssembly)
        {
            if (executingAssembly == null)
            {
                throw new ArgumentNullException(nameof(executingAssembly));
            }

            this.AddAssembly(executingAssembly.GetName().Name);
            return this;
        }

        public ResourceUriBuilder AddPublicKey()
        {
            return this;
        }

        public ResourceUriBuilder AddAuthorityAppliction()
        {
            return this.AddAuthority(UriPackApplication);
        }
    }
}