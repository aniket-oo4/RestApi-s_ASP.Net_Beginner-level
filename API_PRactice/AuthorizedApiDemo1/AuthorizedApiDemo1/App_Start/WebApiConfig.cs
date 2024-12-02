using AuthorizedApiDemo1.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AuthorizedApiDemo1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new JwtAuthenticationFilter());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
