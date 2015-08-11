// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="EntityToNullInt.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper for data entities to nullable integer.</summary>
// ***********************************************************************
using System;
using System.Diagnostics.CodeAnalysis;
using BI.Core.Models;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Map data entities to nullable integer.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EntityToNullInt : LoopValueInjection
    {
        /// <summary>
        /// Matching entity and nullable integer for mapping
        /// </summary>
        /// <param name="sourceType">Source type</param>
        /// <param name="targetType">Target type</param>
        /// <returns>Match or not</returns>
        protected override bool TypesMatch(Type sourceType, Type targetType)
        {
            return sourceType.IsSubclassOf(typeof(Entity)) && targetType == typeof(int?);
        }

        /// <summary>
        /// Set value to entity
        /// </summary>
        /// <param name="o">Any object</param>
        /// <returns>Null or entity object</returns>
        protected override object SetValue(object o)
        {
            if (o == null) return null;
            return (o as Entity).Uid;
        }
    }
}