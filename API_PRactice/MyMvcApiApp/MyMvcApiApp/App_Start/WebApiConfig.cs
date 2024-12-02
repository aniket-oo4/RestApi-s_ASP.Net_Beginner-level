using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyMvcApiApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Enable attribute routing
            //kconfig.MapHttpAttributeRoutes();

            // Default API route

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "MathApi",
                routeTemplate: "api/{controller}/{action}/{num1}/{num2}",
                defaults: new { controller = "Math", action = "AddNumbers" }
                );

        }



    }
}
