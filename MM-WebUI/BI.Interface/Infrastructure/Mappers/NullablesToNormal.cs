// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="NullablesToNormal.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper for nullable type to standard data type (int, datetime, float, etc,.).</summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Map nullable type to standard data type (int, datetime, float, etc,.).
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NullablesToNormal : ConventionInjection
    {
        /// <summary>
        /// Matching standard datatype (int, datetime) for mapping
        /// </summary>
        /// <param name="c">ConventionInfo</param>
        /// <returns>Match or not</returns>
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name &&
                   Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type;
        }
    }
}