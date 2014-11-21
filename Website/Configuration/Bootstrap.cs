using Microsoft.Owin;
using Owin;
using PayMe.Web.Infrastructure.Configuration;

[assembly: OwinStartup(typeof(Payme.Website.Configuration.Bootstrap))]
namespace Payme.Website.Configuration
{
    public class Bootstrap
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        public void Configuration(IAppBuilder app)
        {
            var builder = new ConfigurationBuilder(app);
            builder.Build();
        }
    }
}
