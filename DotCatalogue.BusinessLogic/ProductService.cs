using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotCatalogue.Model;
using DotCatalogue.DataAccess;

namespace DotCatalogue.BusinessLogic
{
    public class ProductService : IProductService
    {
        #region Private Variables
        private DotCatalogueContext _db; 
        #endregion

        #region Constructors
        public ProductService(DotCatalogueContext db)
        {
            _db = db;
        }
        #endregion

        #region IProductService implementation
        public Product AddOrUpdateProduct(Product item)
        {
            bool itemExists = item.Id > 0 && _db.Products.Any(p => p.Id == item.Id);

            if (itemExists)
            {
                _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.Products.Add(item);
            }

            _db.SaveChanges();

            return item;
        }

        public Product AddProduct(Product item)
        {
            _db.Products.Add(item);
            _db.SaveChanges();

            return item;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _db.Products;
        }

        public Product GetProductById(int itemId)
        {
            return _db.Products.Find(itemId);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _db.Products.Where(p => p.CategoryId == categoryId);
        }

        public Product RemoveProduct(int itemId)
        {
            Product item = _db.Products.Find(itemId);
            if(item != null)
            {
                _db.Products.Remove(item);
                _db.SaveChanges();

                return item;
            }

            return null;
        }

        public Product UpdateProduct(Product item)
        {
            bool productExists = item.Id > 0 && _db.Products.Any(c => c.Id == item.Id);
            if (productExists)
            {
                _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return item;
            }

            return null;
        }
        #endregion
    }
}
