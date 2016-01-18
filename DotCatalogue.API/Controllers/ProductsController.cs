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
    /// Controller of Product entity
    /// </summary>
    public class ProductsController : ApiController
    {
        #region Private variables
        private IProductService _prodService;
        #endregion

        #region Constructors
        /// <summary>
        /// Instantiate ProductsController
        /// </summary>
        /// <param name="prodService"></param>
        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        } 
        #endregion

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProducts()
        {
            return _prodService.GetAllProducts().AsQueryable();
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = _prodService.GetProductById(id);
            if (product != null)
                return Ok(product);

            return NotFound();
        }

        /// <summary>
        /// Insert new product
        /// </summary>
        /// <param name="product">Product object</param>
        /// <returns></returns>
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedProduct = _prodService.AddProduct(product);
            if (addedProduct == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        /// <summary>
        /// Update existing product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <param name="product">Product object</param>
        /// <returns></returns>
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != product.Id)
                return BadRequest();

            try
            {
                var updatedProduct = _prodService.UpdateProduct(product);
                if (updatedProduct == null)
                    return NotFound();
            }
            catch (Exception)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Remove a product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns></returns>
        public IHttpActionResult DeleteProduct(int id)
        {
            var product = _prodService.RemoveProduct(id);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
        }
    }
}
