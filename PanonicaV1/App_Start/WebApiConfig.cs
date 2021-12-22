using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using PanonicaV1.Resolver;
using PanonicaV1.Models;
using PanonicaV1.Models.DTOs;
using PanonicaV1.Interfaces;
using PanonicaV1.Repository;
using AutoMapper;

namespace PanonicaV1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // CORS
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Tracing
            config.EnableSystemDiagnosticsTracing();


            // Unity
            var container = new UnityContainer();

            container.RegisterType<IProductRepository, ProductsRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISeasonRepository, SeasonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPackageRepository, PackageRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IContractRepository, ContractRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IClientCompanyRepository, ClientCompanyRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);



            ///AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Packaging, PackagingDTO>();
            });

        }
    }
}
