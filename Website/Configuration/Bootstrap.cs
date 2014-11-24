using System;
using System.Web.Hosting;
using Microsoft.Owin;
using Owin;
using PayMe.Web.Configuration;

[assembly: OwinStartup(typeof(Payme.Website.Configuration.Bootstrap))]
namespace Payme.Website.Configuration
{
    public class Bootstrap
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
        public void Configuration(IAppBuilder app)
        {
            // Required in web.config by SqlCe connection
            AppDomain.CurrentDomain.SetData("DataDirectory", HostingEnvironment.MapPath("~/App_Data/"));

            var owin = new OwinConfiguration();
            owin.Configure(app);
        }
    }
}
