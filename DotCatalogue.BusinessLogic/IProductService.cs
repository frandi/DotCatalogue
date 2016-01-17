using DotCatalogue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCatalogue.BusinessLogic
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        Product GetProductById(int itemId);
        Product AddProduct(Product item);
        Product AddOrUpdateProduct(Product item);
        Product UpdateProduct(Product item);
        Product RemoveProduct(int itemId);
    }
}
