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
    public class ProductsController : ApiController
    {
        #region Private variables
        private IProductService _prodService;
        #endregion

        #region Constructors
        public ProductsController(IProductService prodService)
        {
            _prodService = prodService;
        } 
        #endregion

        public IQueryable<Product> GetProducts()
        {
            return _prodService.GetAllProducts().AsQueryable();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _prodService.GetProductById(id);
            if (product != null)
                return Ok(product);

            return NotFound();
        }

        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var addedProduct = _prodService.AddProduct(product);
            if (addedProduct == null)
                return BadRequest();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

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
