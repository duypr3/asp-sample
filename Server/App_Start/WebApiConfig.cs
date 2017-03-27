﻿using DAL;
using DAL.Repository;
using DryIoc;
using DryIoc.WebApi;
using Microsoft.Owin.Security.OAuth;
using Services.Implementation;
using Services.Interface;
using System.Web.Http;

namespace Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            //var container = new Container(
            //        rules: Rules.Default,
            //        scopeContext: new AsyncExecutionFlowScopeContext()).WithWebApi(config);

            var container = new Container(
                    rules => rules.With(FactoryMethod.ConstructorWithResolvableArguments)
                    ).WithWebApi(config);
                                   
                          
            //scopeContext: new AsyncExecutionFlowScopeContext()).WithWebApi(config);

            container.Register<IDbContextFactory, DbContextFactory>(Reuse.Singleton);
           // container.Register<IUnitOfWork, UnitOfWork>(Reuse.Singleton);
            container.Register<ILoginRepository, LoginRepository>(Reuse.Transient);
            container.Register<ILoginService, LoginService>(Reuse.Transient);

           /* container.RegisterMany(new[] { typeof(LoginRepository).Assembly }, nonPublicServiceTypes: true);
            container.RegisterMany(new[] { typeof(LoginService).Assembly }, nonPublicServiceTypes: true);*/
            
            //container.Register<IUnitOfWork, UnitOfWork>(made: Made.Of(FactoryMethod.ConstructorWithResolvableArguments));
            //container.Register<IStudentService, StudentService>(made: Made.Of(FactoryMethod.ConstructorWithResolvableArguments));
            //container.RegisterMany<UnitOfWork>(serviceTypeCondition: type => type.IsInterface);
            //container.RegisterMany<StudentService>(serviceTypeCondition: type => type.IsInterface);


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}