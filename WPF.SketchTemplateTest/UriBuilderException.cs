// -----------------------------------------------------------------------
//  <copyright file="UriBuilderException.cs" company="Anori Soft">
//      Copyright (c) Anori Soft Martin Egli. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Anori.WPF.Resources.Exceptions
{
    #region

    using global::WPF.SketchTemplateTest.Annotations;
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    #endregion

    /// <inheritdoc />
    /// <summary>
    /// Basic class for all Module Initializer Exceptions
    /// </summary>
    /// <seealso cref="T:System.Exception" />
    [Serializable]
    public abstract class UriBuilderException : Exception
    {
        #region Public Methods

        /// <inheritdoc />
        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            base.GetObjectData(info, context);
        }

        #endregion Public Methods

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UriBuilderException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <inheritdoc />
        protected UriBuilderException([NotNull] string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UriBuilderException"/> class.
        /// </summary>
        /// <inheritdoc />
        protected UriBuilderException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UriBuilderException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        /// <returns></returns>
        /// <inheritdoc />
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected UriBuilderException([NotNull] SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Protected Constructors
    }
}