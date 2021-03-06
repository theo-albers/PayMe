﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using PayMe.Runtime.Contracts;

namespace PayMe.Web.Configuration.Dependencies
{
    public class WebApiModule : Autofac.Module
    {
        private readonly HttpConfiguration _config;

        public WebApiModule(HttpConfiguration config)
        {
            Argument.RequireNotNull(config, "config");

            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            Argument.RequireNotNull(builder, "builder");

            builder.RegisterApiControllers(GetControllerAssemblies(_config).ToArray());

            base.Load(builder);
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
