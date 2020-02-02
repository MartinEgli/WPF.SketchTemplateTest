// -----------------------------------------------------------------------
//  <copyright file="PropertyAlreadySetException.cs" company="Anori Soft">
//      Copyright (c) Anori Soft Martin Egli. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace WPF.SketchTemplateTest
{
    #region

    using Anori.WPF.Resources.Exceptions;
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;
    using WPF.SketchTemplateTest.Annotations;

    #endregion

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class PropertyAlreadySetException : UriBuilderException
    {
        public PropertyAlreadySetException([NotNull] string propertyName)
            : base(propertyName)
        {
        }

        public PropertyAlreadySetException()
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
        protected PropertyAlreadySetException([NotNull] SerializationInfo info, [NotNull] StreamingContext context)
            : base(info, context)
        {
        }
    }
}