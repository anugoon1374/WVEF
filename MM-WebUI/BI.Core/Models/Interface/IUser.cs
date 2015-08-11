using System;
using System.Collections.Generic;

namespace BI.Core.Models.Interface
{
    public interface IUser
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        string Password { get; set; }
    }

    /// <summary>
    /// Interface IApplicationUser
    /// </summary>
    public interface IApplicationUser : IUser
    {
        /// <summary>
        /// Gets or sets the user first name.
        /// </summary>
        /// <value>The user first name.</value>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the user last name.
        /// </summary>
        /// <value>The user last name.</value>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user email.
        /// </summary>
        /// <value>The user email.</value>
        string Email { get; set; }

        string LoginName { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateLastLogin { get; set; }

        /// <summary>
        /// Gets or sets the user role(s).
        /// </summary>
        /// <value>The user role(s).</value>
        IList<IRole> Roles { get; set; }
    }

    /// <summary>
    /// Interface IRole
    /// </summary>
    public interface IRole
    {
        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the role description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }
    }
}