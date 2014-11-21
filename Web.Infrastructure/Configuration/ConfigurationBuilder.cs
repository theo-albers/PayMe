using System;
using System.Diagnostics.Contracts;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;

namespace PayMe.Web.Infrastructure.Configuration
{
    public class ConfigurationBuilder
    {
        private readonly IAppBuilder _app;

        public ConfigurationBuilder(IAppBuilder app)
        {
            Contract.Requires(app != null);
            _app = app;
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        public void Build()
        {
            // New code: Add the error page middleware to the pipeline. 
            _app.UseErrorPage();
            CreateConfiguration(_app);

            _app.Run(context =>
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

        private static void CreateConfiguration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

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

    }
}
