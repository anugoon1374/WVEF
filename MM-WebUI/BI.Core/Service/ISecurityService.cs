// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 05-08-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 05-08-2015
// ***********************************************************************
// <copyright file="ISecurityService.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface/contract for security service.</summary>
// ***********************************************************************
using System;

namespace BI.Core.Service
{
    /// <summary>
    /// Represents the interface for security service.
    /// </summary>
    public interface ISecurityService
    {
        #region TOKEN GENERATION

        /// <summary>
        /// Generates the expiable token.
        /// </summary>
        /// <param name="uid">The unique identifier.</param>
        /// <param name="time">The time span before token expire.</param>
        /// <returns>The authentication token.</returns>
        string GenerateToken(ulong uid, TimeSpan time);

        #endregion TOKEN GENERATION

        #region ENCRYPTION

        /// <summary>
        /// Encrypts the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="key">The key.</param>
        /// <returns>Encrypted content.</returns>
        string Encrypt(string content, string key);

        /// <summary>
        /// Decrypts the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="key">The key.</param>
        /// <returns>Decrypted content.</returns>
        string Decrypt(string content, string key);

        #endregion ENCRYPTION
    }
}
