using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SuperFastBlogAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
              name: "User",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { controller = "User", action = "GetUsers", id = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
             name: "Article",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { controller = "Article", action = "GetArticles", id = RouteParameter.Optional }
         );

            config.Routes.MapHttpRoute(
             name: "Contact",
             routeTemplate: "api/{controller}/{id}",
             defaults: new { controller = "Contact", action = "GetAllContacts", id = RouteParameter.Optional }
         );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            
        }
    }
}
