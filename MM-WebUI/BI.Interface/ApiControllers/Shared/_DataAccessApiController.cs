// ***********************************************************************
// Assembly         : BI.Interface
// Author           : Anugoon Leelaphattarakij
// Created          : 04-20-2015
//
// Last Modified By : Anugoon Leelaphattarakij
// Last Modified On : 04-20-2015
// ***********************************************************************
// <copyright file="_DataAccessApiController.cs" company="Beyond Inspira">
//     Copyright © Anugoon L. 2015
// </copyright>
// <summary>Shared API Controller with implemented data access actions.</summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BI.Auxiliary;
using BI.Core.Models;
using BI.Core.Service;
using BI.Interface.Infrastructure.Mappers;
using BI.Interface.ViewModels;

namespace BI.Interface.ApiControllers
{
    /// <summary>
    /// API Controller with implemented data access service.
    /// </summary>
    /// <typeparam name="TEntity">Entity based class type.</typeparam>
    /// <typeparam name="TCreateInput">Create input view model.</typeparam>
    /// <typeparam name="TEditInput">Edit input view model.</typeparam>
    public class DataAccessApiController<TEntity, TCreateInput, TEditInput> : BaseApiController
        where TCreateInput : EntityViewModel, new()
        where TEditInput : EntityViewModel, new()
        where TEntity : Entity, new()
    {
        #region PROPERTIES

        /// <summary>
        /// The data access service
        /// </summary>
        protected readonly IDataService<TEntity> DataService;

        /// <summary>
        /// The data mapper for create view model
        /// </summary>
        private readonly IMapper<TEntity, TCreateInput> _createMapper;

        /// <summary>
        /// The data mapper for edit view model
        /// </summary>
        private readonly IMapper<TEntity, TEditInput> _editMapper;

        #endregion PROPERTIES

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessApiController{TEntity,TCreateInput,TEditInput}" /> class.
        /// </summary>
        /// <param name="dataService">The data service.</param>
        /// <param name="createMapper">The create data mapper.</param>
        /// <param name="editMapper">The edit data mapper.</param>
        protected DataAccessApiController(IDataService<TEntity> dataService, IMapper<TEntity, TCreateInput> createMapper, IMapper<TEntity, TEditInput> editMapper)
        {
            DataService = dataService;
            _createMapper = createMapper;
            _editMapper = editMapper;
        }

        #endregion CONSTRUCTOR

        #region CREATE / INSERT

        /// <summary>
        /// Creates/Inserts the new item/object into repository.
        /// </summary>
        /// <param name="inputData">The input data (create view model).</param>
        /// <returns>IHttpActionResult with newly created/inserted item.</returns>
        /// <remarks>
        /// This method description will not show in help page because it use generic argument which is not support yet.
        /// Read more at: http://stackoverflow.com/questions/19646987/webapi-help-page-documentation-for-return-or-parameter-model-class-properties
        /// </remarks>
        [HttpPost]
        public virtual IHttpActionResult Create(TCreateInput inputData)
        {
            // Input
            if (inputData == null)
            {
                return BadRequest(new ArgumentNullException("inputData").ToString());
            }

            // Process
            var newItemId = DataService.Insert(_createMapper.MapToEntity(inputData, new TEntity()));

            // Output
            var outputData = DataService.Get(newItemId);
            if (outputData == null)
            {
                return NotFound();
            }
            return CreatedAtRoute("Web API Get Single Resource", new { uid = newItemId }, outputData);
        }

        #endregion CREATE / INSERT

        #region READ

        /// <summary>
        /// Gets the specified item/object by unique identifier from repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>IHttpActionResult with specified item.</returns>
        [HttpGet]
        public virtual IHttpActionResult Get(ulong uid)
        {
            // Input
            if (uid <= 0)
            {
                return BadRequest("Invalid identifier");
            }

            // Output
            var outputData = DataService.Get(uid);
            if (outputData == null)
            {
                return NotFound();
            }
            return Ok(outputData);
        }

        /// <summary>
        /// Gets all items/objects from repository.
        /// </summary>
        /// <returns>The item collection (IEnumerable).</returns>
        /// <exception cref="HttpResponseException">404</exception>
        [HttpGet]
        public virtual IEnumerable<TEntity> GetAll()
        {
            // Output
            var outputData = DataService.GetAll();
            if (outputData == null || !outputData.Any())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return outputData;
        }

        /// <summary>
        /// Gets specific size and page of items/objects from repository.
        /// </summary>
        /// <param name="p">The page number.</param>
        /// <param name="s">The size of item per page.</param>
        /// <returns>The item collection (IEnumerable).</returns>
        /// <exception cref="HttpResponseException">404</exception>
        [HttpGet]
        public virtual IEnumerable<TEntity> GetAll(int p, int s)
        {
            // Input
            if (p <= 0 || s <= 0)
            {
                var response = Request.CreateResponse(HttpStatusCode.BadRequest);
                response.ReasonPhrase = "Page Number and Page Size must be more than 0";
                throw new HttpResponseException(response);
            }

            // Output
            var outputData = DataService.GetAll().Page(p, s);
            if (outputData == null || !outputData.Any())
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return outputData.ToList();
        }

        #endregion READ

        #region UPDATE

        /// <summary>
        /// Update the specified items/objects in repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <param name="inputData">The input data (edit view model).</param>
        /// <returns>IHttpActionResult with updated created/inserted item.</returns>
        /// <remarks>
        /// This method description will not show in help page because it use generic argument which is not support yet.
        /// Read more at: http://stackoverflow.com/questions/19646987/webapi-help-page-documentation-for-return-or-parameter-model-class-properties
        /// </remarks>
        [HttpPut]
        public virtual IHttpActionResult Update(ulong uid, TEditInput inputData)
        {
            // Input
            if (uid <= 0)
            {
                return BadRequest(new ArgumentOutOfRangeException("uid").ToString());
            }

            if (inputData == null)
            {
                return BadRequest(new ArgumentNullException("inputData").ToString());
            }

            // Process
            var existingData = DataService.Get(uid);
            if (existingData == null)
            {
                return NotFound();
            }
            _editMapper.MapToEntity(inputData, existingData);
            DataService.Save();

            // Output
            var outputData = DataService.Get(uid);
            return CreatedAtRoute("Web API Get Single Resource", new { uid = uid }, outputData);
        }

        #endregion UPDATE

        #region DELETE / RESTORE

        /// <summary>
        /// Deletes the specified item/object in repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>IHttpActionResult.</returns>
        [HttpDelete]
        public virtual IHttpActionResult Delete(ulong uid)
        {
            // Input
            if (uid <= 0)
            {
                return BadRequest(new ArgumentOutOfRangeException("uid").ToString());
            }

            // Process
            DataService.Delete(uid);

            // Output
            return Ok();
        }

        /// <summary>
        /// Restores the specified deleted item/object in repository.
        /// </summary>
        /// <param name="uid">The item's unique identifier.</param>
        /// <returns>IHttpActionResult with restored data.</returns>
        [HttpPost]
        public virtual IHttpActionResult Restore(ulong uid)
        {
            // Input
            if (uid <= 0)
            {
                return BadRequest(new ArgumentOutOfRangeException("uid").ToString());
            }

            if (!typeof(TEntity).IsSubclassOf(typeof(DelEntity)) && (typeof(TEntity) != typeof(DelEntity)))
            {
                return BadRequest(new NotSupportedException("The entity is not support restore command").ToString());
            }

            // Process
            DataService.Restore(uid);

            // Output
            var outputData = DataService.Get(uid);
            if (outputData == null) { return NotFound(); }
            return CreatedAtRoute("Web API Get Single Resource", new { uid = uid }, outputData);
        }

        #endregion DELETE / RESTORE
    }
}