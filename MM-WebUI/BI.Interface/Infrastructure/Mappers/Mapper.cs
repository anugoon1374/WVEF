// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="Mapper.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Data model mapper.</summary>
// ***********************************************************************
using System.Diagnostics.CodeAnalysis;
using Omu.ValueInjecter;

namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// Data model mapper.
    /// </summary>
    /// <typeparam name="TEntity">Data entity (data model)</typeparam>
    /// <typeparam name="TInput">View model (Create/Edit view model)</typeparam>
    [ExcludeFromCodeCoverage]
    public class Mapper<TEntity, TInput> : IMapper<TEntity, TInput>
        where TEntity : class, new()
        where TInput : new()
    {
        /// <summary>
        /// Mapping data model to view model.
        /// </summary>
        /// <param name="entity">Data entity (data model)</param>
        /// <returns>Entity in view model format</returns>
        public virtual TInput MapToView(TEntity entity)
        {
            var input = new TInput();
            input.InjectFrom(entity)
                .InjectFrom<NormalToNullables>(entity)
                .InjectFrom<EntitiesToInts>(entity);
            return input;
        }

        /// <summary>
        /// Mapping view model to data model (entity).
        /// </summary>
        /// <param name="input">View model (Create/Edit view model)</param>
        /// <param name="entity">Data entity (Data model)</param>
        /// <returns>Entity in data model format</returns>
        public virtual TEntity MapToEntity(TInput input, TEntity entity)
        {
            entity.InjectFrom(input)
               .InjectFrom<IntsToEntities>(input)
               .InjectFrom<NullablesToNormal>(input);
            return entity;
        }
    }
}