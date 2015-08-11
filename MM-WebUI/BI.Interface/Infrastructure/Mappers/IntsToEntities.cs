// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="IntsToEntities.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper for integer to any data entities.</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using BI.Core.Models;
using BI.Core.Repository;
using BI.Infrastructure;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Map integer to any data entities.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class IntsToEntities : ConventionInjection
    {
        /// <summary>
        /// Matching entity and integer for mapping
        /// </summary>
        /// <param name="c">ConventionInfo</param>
        /// <returns>Match or not</returns>
        protected override bool Match(ConventionInfo c)
        {
            if (c.SourceProp.Name != c.TargetProp.Name) return false;
            var s = c.SourceProp.Type;
            var t = c.TargetProp.Type;

            if (!s.IsGenericType || !t.IsGenericType
                || s.GetGenericTypeDefinition() != typeof(IEnumerable<>)
                || t.GetGenericTypeDefinition() != typeof(ICollection<>)) return false;

            return s.GetGenericArguments()[0] == (typeof(int))
                   && (t.GetGenericArguments()[0].IsSubclassOf(typeof(Entity)));
        }

        /// <summary>
        /// Set value to entity
        /// </summary>
        /// <param name="c">ConventionInfo</param>
        /// <returns>Null or entity object</returns>
        protected override object SetValue(ConventionInfo c)
        {
            if (c.SourceProp.Value == null) return null;
            dynamic repo = IoC.Resolve(typeof(IRepository<>).MakeGenericType(c.TargetProp.Type.GetGenericArguments()[0]));
            dynamic list = Activator.CreateInstance(typeof(List<>).MakeGenericType(c.TargetProp.Type.GetGenericArguments()[0]));

            foreach (var i in ((IEnumerable<int>)c.SourceProp.Value))
                list.Add(repo.Get(i));
            return list;
        }
    }
}