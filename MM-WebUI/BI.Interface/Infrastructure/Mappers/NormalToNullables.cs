// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="NormalToNullables.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper for standard data type (int, datetime, float, etc,.) to nullable type.</summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Map standard data type (int, datetime, float, etc,.) to nullable type.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class NormalToNullables : ConventionInjection
    {
        /// <summary>
        /// Matching standard data type (int, datetime, float, etc,.) for mapping.
        /// </summary>
        /// <param name="c">ConventionInfo</param>
        /// <returns>Match or not</returns>
        protected override bool Match(ConventionInfo c)
        {
            //ignore int = 0 and DateTime = to 1/01/0001
            if (c.SourceProp.Type == typeof(DateTime) && (DateTime)c.SourceProp.Value == default(DateTime) ||
                (c.SourceProp.Type == typeof(int) && (int)c.SourceProp.Value == default(int)))
                return false;

            return (c.SourceProp.Name == c.TargetProp.Name &&
                    c.SourceProp.Type == Nullable.GetUnderlyingType(c.TargetProp.Type));
        }
    }
}