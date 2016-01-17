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
    public class CategoriesController : ApiController
    {
        #region Private variables
        private ICategoryService _catService;
        #endregion

        #region Constructors
        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }
        #endregion

        #region REST methods
        public IQueryable<Category> GetCategories()
        {
            return _catService.GetRootCategories().AsQueryable();
        }

        public IHttpActionResult GetCategory(int id)
        {
            var category = _catService.GetCategoryById(id);
            if (category != null)
                return Ok(category);

            return NotFound();
        }

        public IHttpActionResult PostCategory(Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedCategory = _catService.AddCategory(category);
            if (addedCategory == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
        }

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
