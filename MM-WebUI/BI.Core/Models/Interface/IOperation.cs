// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="IOperation.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface collection for Operation management domain.</summary>
// ***********************************************************************
using System;

namespace BI.Core.Models.Interface
{
    /// <summary>
    /// Represents the interface for status card attributes.
    /// </summary>
    /// <remarks>
    /// Status card is best practice for track and record status of real world object.
    /// </remarks>
    public interface IStatusCard
    {
        /// <summary>
        /// Gets or sets the current status of the card.
        /// </summary>
        /// <value>The current status of the card.</value>
        IStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the card description.
        /// </summary>
        /// <value>The card description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the card created date.
        /// </summary>
        /// <value>The card created date.</value>
        DateTime CreatedDate { get; set; }
    }

    /// <summary>
    /// Represents the interface for Kanban card attributes.
    /// </summary>
    /// <remarks>
    /// Kanban card is an operation management standard for track and record status of real world object.
    /// </remarks>
    public interface IKanbanCardLite : IStatusCard
    {
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        ulong Quantity { get; set; }

        /// <summary>
        /// Gets or sets the card due date.
        /// </summary>
        /// <value>The card due date.</value>
        DateTime DueDate { get; set; }
    }
}