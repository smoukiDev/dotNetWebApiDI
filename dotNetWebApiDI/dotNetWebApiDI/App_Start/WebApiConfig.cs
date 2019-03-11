using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using dotNetWebApiDI.Core;
using dotNetWebApiDI.Models;
using dotNetWebApiDI.Persistance;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Unity;

namespace dotNetWebApiDI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config
                .Formatters
                .Remove(config.Formatters.XmlFormatter);
            config
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
            config
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .Formatting = Formatting.Indented;

            SetDependencyInjection(config);
        }

        private static void SetDependencyInjection(HttpConfiguration config)
        {
            var container = new UnityContainer()
                .RegisterType<IRepository<Customer>, CustomesRepository>()
                .RegisterInstance(new ShopDbContext("name=Shop"));

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
