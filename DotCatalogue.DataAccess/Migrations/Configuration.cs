namespace DotCatalogue.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DotCatalogue.DataAccess.DotCatalogueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DotCatalogue.DataAccess.DotCatalogueContext context)
        {
            
        }
    }
}
