using LeaveApplicationAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace LeaveApplicationAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new JwtAuthenticationFilter());
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
