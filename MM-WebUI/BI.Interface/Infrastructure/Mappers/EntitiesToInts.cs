// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="EntitiesToInts.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper for data entities to integer.</summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BI.Core.Models;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Map data entities to integer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EntitiesToInts : ConventionInjection
    {
        /// <summary>
        /// Matching entity and integer for mapping.
        /// </summary>
        /// <param name="c">ConventionInfo</param>
        /// <returns>Match or not</returns>
        protected override bool Match(ConventionInfo c)
        {
            if (c.SourceProp.Name != c.TargetProp.Name) return false;
            var s = c.SourceProp.Type;
            var t = c.TargetProp.Type;

            if (!s.IsGenericType || !t.IsGenericType
                || s.GetGenericTypeDefinition() != typeof(ICollection<>)
                || t.GetGenericTypeDefinition() != typeof(IEnumerable<>)) return false;

            return t.GetGenericArguments()[0] == (typeof(int))
                   && (s.GetGenericArguments()[0].IsSubclassOf(typeof(Entity)));
        }

        /// <summary>
        /// Set value to entity.
        /// </summary>
        /// <param name="v">ConventionInfo</param>
        /// <returns>Null or entity object</returns>
        protected override object SetValue(ConventionInfo v)
        {
            return v.SourceProp.Value == null ? null : (v.SourceProp.Value as IEnumerable<Entity>).Select(o => o.Uid);
        }
    }
}