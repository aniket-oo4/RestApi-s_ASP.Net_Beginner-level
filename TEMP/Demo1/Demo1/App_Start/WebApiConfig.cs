﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Demo1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //webApi Routes 
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //its for content negotiation YT PArt-5 video
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
           
            
        }
    }
}
