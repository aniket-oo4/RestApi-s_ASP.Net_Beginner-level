using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContriesAPIDemoApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.Routes.MapHttpRoute(
            //     name: "CountryApi",
            //     routeTemplate: "api/CountryRepository/{id}",
            //     defaults: new { controller = "CountryRepository", id = RouteParameter.Optional }
            // );
        }
    }
}
