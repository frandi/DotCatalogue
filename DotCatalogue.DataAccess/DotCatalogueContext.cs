using DotCatalogue.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCatalogue.DataAccess
{
    public class DotCatalogueContext: DbContext
    {
        #region Constructors
        public DotCatalogueContext()
            : base("DotCatalogueConnection")
        {

        }

        public DotCatalogueContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }
        #endregion

        #region Entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}