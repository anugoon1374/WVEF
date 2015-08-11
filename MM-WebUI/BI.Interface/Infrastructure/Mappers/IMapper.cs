// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-27-2015
// ***********************************************************************
// <copyright file="IMapper.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>The interface for data transfer object (DTO) or data model mapper interface.</summary>
// ***********************************************************************
namespace BI.Interface.Infrastructure.Mappers
{
    /// <summary>
    /// The interface for data model mapper.
    /// </summary>
    /// <typeparam name="TEntity">Data entity (Data model)</typeparam>
    /// <typeparam name="TInput">View model (Create/Edit view model)</typeparam>
    public interface IMapper<TEntity, TInput>
        where TEntity : class, new()
        where TInput : new()
    {
        /// <summary>
        /// Mapping data model to view model
        /// </summary>
        /// <param name="entity">Data entity (data model)</param>
        /// <returns>Entity in view model format</returns>
        TInput MapToView(TEntity entity);

        /// <summary>
        /// Mapping view model to data model (entity)
        /// </summary>
        /// <param name="input">View model (Create/Edit view model)</param>
        /// <param name="entity">Data entity (Data model)</param>
        /// <returns>Entity in data model format</returns>
        TEntity MapToEntity(TInput input, TEntity entity);
    }
}