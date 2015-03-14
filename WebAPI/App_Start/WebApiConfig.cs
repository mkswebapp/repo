using DemoWebAPI.DB;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.OData.Routing;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Product>("Products");
            //config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());


            config.Routes.MapODataRoute("odata", "odata", GenerateEdmModel());


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }





        private static Microsoft.Data.Edm.IEdmModel GenerateEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<ErrorLog>("ErrorLogs");
            builder.EntitySet<Address>("Addresses");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<CustomerAddress>("CustomerAddresses");
            builder.EntitySet<Product>("Products");
            builder.EntitySet<ProductCategory>("ProductCategories");
            builder.EntitySet<ProductDescription>("ProductDescriptions");
            builder.EntitySet<ProductModel>("ProductModels");
            builder.EntitySet<ProductModelProductDescription>("ProductModelProductDescriptions");
            builder.EntitySet<SalesOrderDetail>("SalesOrderDetails");
            builder.EntitySet<SalesOrderHeader>("SalesOrderHeaders");
            builder.EntitySet<BuildVersion>("BuildVersions");

            return builder.GetEdmModel();
        }

    }
}
