// ***********************************************************************
// Assembly         : BI.Core
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-30-2015
// ***********************************************************************
// <copyright file="ICommon.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface collection for common things.</summary>
// ***********************************************************************

using System;
using System.Spatial;

namespace BI.Core.Models.Interface
{
    /// <summary>
    /// Represents the interface for location information attributes.
    /// </summary>
    public interface ILocation
    {
        /// <summary>
        /// Gets or sets the location description.
        /// </summary>
        /// <value>The location description.</value>
        string LocationDescription { get; set; }

        /// <summary>
        /// Gets or sets the coordinate of the location (latitude, longitude).
        /// </summary>
        /// <value>The coordinate.</value>
        CoordinateSystem Coordinate { get; set; }
    }

    /// <summary>
    /// Represents the interface for opening and closing time attributes.
    /// </summary>
    public interface IOpenAndCloseTime
    {
        /// <summary>
        /// Gets or sets the opening time.
        /// </summary>
        /// <value>The opening time.</value>
        TimeSpan OpeningTime { get; set; }

        /// <summary>
        /// Gets or sets the closing time.
        /// </summary>
        /// <value>The closing time.</value>
        TimeSpan ClosingTime { get; set; }
    }

    /// <summary>
    /// Represents the interface for status attributes.
    /// </summary>
    public interface IStatus
    {
        /// <summary>
        /// Gets or sets the name of status.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of status.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the status update time.
        /// </summary>
        /// <value>The status update time.</value>
        DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// Represents the interface for log attributes.
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Gets or sets the detail of log.
        /// </summary>
        /// <value>The detail.</value>
        string Detail { get; set; }

        /// <summary>
        /// Gets or sets the date and time log has been created.
        /// </summary>
        /// <value>The date and time log has been created.</value>
        DateTime DateTime { get; set; }
    }
}