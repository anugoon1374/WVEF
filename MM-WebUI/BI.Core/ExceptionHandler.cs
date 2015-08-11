// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-17-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="ExceptionHandler.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The collection of extended exception handler.</summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;

namespace BI.Core
{
    /// <summary>
    /// Base class for exception handler.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ExceptionHandler : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ExceptionHandler(string message)
            : base(message)
        {
        }
    }

    /// <summary>
    /// Exception handler for missing configuration require to run specified logic.
    /// </summary>
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class MissingConfigurationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandler" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MissingConfigurationException(string message)
            : base(message)
        {
        }
    }
}