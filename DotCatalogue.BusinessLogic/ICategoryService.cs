using DotCatalogue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCatalogue.BusinessLogic
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetRootCategories();
        Category GetCategoryById(int categoryId);
        Category AddCategory(Category category);
        Category AddOrUpdateCategory(Category category);
        Category UpdateCategory(Category category);
        Category RemoveCategory(int categoryId);
    }
}
