using DotCatalogue.BusinessLogic;
using DotCatalogue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DotCatalogue.API.Controllers
{
    /// <summary>
    /// Controller for Category entity
    /// </summary>
    public class CategoriesController : ApiController
    {
        #region Private variables
        private ICategoryService _catService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiate CategoriesController
        /// </summary>
        /// <param name="catService">Object of type ICategoryService</param>
        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }
        #endregion

        #region REST methods
        /// <summary>
        /// Get all root categories
        /// </summary>
        /// <returns></returns>
        public IQueryable<Category> GetCategories()
        {
            return _catService.GetRootCategories().AsQueryable();
        }

        /// <summary>
        /// Get a category by id
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns></returns>
        public IHttpActionResult GetCategory(int id)
        {
            var category = _catService.GetCategoryById(id);
            if (category != null)
                return Ok(category);

            return NotFound();
        }

        /// <summary>
        /// Insert new category
        /// </summary>
        /// <param name="category">Category object</param>
        /// <returns></returns>
        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedCategory = _catService.AddCategory(category);
            if (addedCategory == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

        /// <summary>
        /// Update existing category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="category">Category object with new values</param>
        /// <returns></returns>
        public IHttpActionResult PutCategory(int id, Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != category.Id)
                return BadRequest();

            try
            {
                var updatedCategory = _catService.UpdateCategory(category);
                if (updatedCategory == null)
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Remove a category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns></returns>
        public IHttpActionResult DeleteCategory(int id)
        {
            var category = _catService.RemoveCategory(id);
            if (category == null)
                return NotFound();
            else
                return Ok(category);
        } 
        #endregion
    }
}
