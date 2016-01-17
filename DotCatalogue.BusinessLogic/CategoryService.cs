using DotCatalogue.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotCatalogue.Model;

namespace DotCatalogue.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        #region Private variables
        private DotCatalogueContext _db;
        #endregion

        #region Constructors
        public CategoryService(DotCatalogueContext db)
        {
            _db = db;
        }
        #endregion

        #region ICategoryService implementation
        public Category AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();

            return category;
        }

        public Category AddOrUpdateCategory(Category category)
        {
            bool categoryExists = category.Id > 0 && _db.Categories.Any(c => c.Id == category.Id);
            if (categoryExists)
            {
                _db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.Categories.Add(category);
            }

            _db.SaveChanges();

            return category;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _db.Categories.Find(categoryId);
        }

        public IEnumerable<Category> GetRootCategories()
        {
            return _db.Categories.Where(c => c.ParentId == null);
        }

        public Category RemoveCategory(int categoryId)
        {
            Category category = _db.Categories.Find(categoryId);
            if(category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();

                return category;
            }

            return null;
        }

        public Category UpdateCategory(Category category)
        {
            bool categoryExists = category.Id > 0 && _db.Categories.Any(c => c.Id == category.Id);
            if (categoryExists)
            {
                _db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return category;
            }

            return null;
        }
        #endregion
    }
}
