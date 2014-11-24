using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using Owin;
using PayMe.DomainModel.Customers;
using PayMe.Runtime.Contracts;
using PayMe.Web.Configuration.Dependencies;

namespace PayMe.Web.Configuration
{
    public class OwinConfiguration // fat class, just to get started and explore the dependencies
    {
        public void Configure(IAppBuilder app)
        {
            Argument.RequireNotNull(app, "app");

            var config = CreateHttpConfiguration();
            ConfigureWebApi(app, config);
            ConfigureDependencies(app, config);
            ConfigureWebServer(app);
            ConfigureEntityFramework();
        }

        private void ConfigureEntityFramework()
        {
            Database.SetInitializer<CustomerDbContext>(new CustomerDbInitializer());
        }

        private HttpConfiguration CreateHttpConfiguration()
        {
            return new HttpConfiguration();
        }

        private void ConfigureWebServer(IAppBuilder app)
        {
            app.UseErrorPage();
            app.Run(context =>
            {
                // New code: Throw an exception for this URI path.
                if (context.Request.Path.Value == "/fail")
                {
                    throw new Exception("Random exception");
                }

                context.Response.ContentType = "text/plain";

                return context.Response.WriteAsync("Hello, world.");
            });
        }

        private void ConfigureWebApi(IAppBuilder app, HttpConfiguration config)
        {
            // Use camel case for JSON data.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
            app.UseWebApi(config);
        }

        private void ConfigureDependencies(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterModule(new WebApiModule(config))
                .RegisterModule(new EntityModelModule())
                .RegisterModule(new DomainModelModule())
                .RegisterModule(new ConfigurationSettingsReader());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
        }

        private IEnumerable<Assembly> GetControllerAssemblies(HttpConfiguration config)
        {
            var api = new System.Web.Http.Description.ApiExplorer(config);

            return (from description in api.ApiDescriptions
                    select description.ActionDescriptor.ControllerDescriptor.ControllerType.Assembly)
                    .Distinct();
        }
    }
}
