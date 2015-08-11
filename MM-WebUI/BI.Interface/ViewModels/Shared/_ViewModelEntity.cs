// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-19-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-19-2015
// ***********************************************************************
// <copyright file="_ViewModelEntity.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Base view model for every entity</summary>
// ***********************************************************************

namespace BI.Interface.ViewModels
{
    /// <summary>
    /// Base class for all view model.
    /// This class use with action filer "ViewModelUserFilter", which automatically add set "IsUserAuthenticated" and "UserName".
    /// </summary>
    public class EntityViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is user authenticated.
        /// </summary>
        /// <value><c>true</c> if this instance is user authenticated; otherwise, <c>false</c>.</value>
        public bool IsUserAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName { get; set; }
    }
}