using DotCatalogue.BusinessLogic;
using DotCatalogue.DataAccess;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DotCatalogue.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Unity
            var container = new UnityContainer();
            container.RegisterInstance<DotCatalogueContext>("Context", new DotCatalogueContext("DotCatalogueConnection"));
            container.RegisterType<IProductService, ProductService>(new InjectionConstructor(new ResolvedParameter<DotCatalogueContext>("Context")));
            container.RegisterType<ICategoryService, CategoryService>(new InjectionConstructor(new ResolvedParameter<DotCatalogueContext>("Context")));
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
