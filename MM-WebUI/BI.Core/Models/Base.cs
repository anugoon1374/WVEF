// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="Base.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The collection of root entity class and interface.</summary>
// ***********************************************************************

using System.ComponentModel.DataAnnotations;

namespace BI.Core.Models
{
    /// <summary>
    /// Represents the base entity.
    /// This entity unifies all class type to make its data accessible using Unit of Work pattern.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// Avoid modifying this value directly. Use "Uid" instead.
        /// </summary>
        /// <value>The unique identifier.</value>
        /// <remarks>
        /// <para>Use 64-bit variable for identifier to prevent number running out.</para>
        /// <para>EF doesn't support unsigned variable, so we have to cast before using.</para>
        /// </remarks>
        /// <seealso href="http://stackoverflow.com/questions/26303631/how-to-use-unsigned-int-long-types-with-entity-framework">How to use unsigned int / long types with Entity Framework?</seealso>
        [Key]
        public long _Uid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        public ulong Uid
        {
            get
            {
                unchecked
                {
                    return (ulong)_Uid;
                }
            }

            set
            {
                unchecked
                {
                    _Uid = (long)value;
                }
            }
        }
    }

    /// <summary>
    /// Represents restorable entity.
    /// Delete action will set 'IsDeleted' flag to false instead of removing it completely.
    /// </summary>
    public class DelEntity : Entity, IDel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this item is deleted.
        /// </summary>
        /// <value><c>true</c> if this item is deleted; otherwise, <c>false</c>.</value>
        public bool IsDeleted { get; set; }
    }

    /// <summary>
    /// Represents the interface for restorable entity.
    /// Delete will set 'IsDeleted' flag to false instead of removing it completely.
    /// </summary>
    public interface IDel
    {
        /// <summary>
        /// Gets or sets a value indicating whether this item is deleted.
        /// </summary>
        /// <value><c>true</c> if this item is deleted; otherwise, <c>false</c>.</value>
        bool IsDeleted { get; set; }
    }
}