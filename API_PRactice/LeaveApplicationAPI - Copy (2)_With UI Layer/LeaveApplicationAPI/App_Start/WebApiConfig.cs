
using LeaveApplicationAPI.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LeaveApplicationAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new JwtAuthenticationFilter());
            config.EnableCors(new EnableCorsAttribute("*", "*", "*")); //for Cors enable
            config.MapHttpAttributeRoutes();// for attributes  and routing 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
