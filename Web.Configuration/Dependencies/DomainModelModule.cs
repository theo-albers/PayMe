﻿using Autofac;
using PayMe.DomainModel.Customers;
using PayMe.Runtime.Contracts;

namespace PayMe.Web.Configuration.Dependencies
{
    public class DomainModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Argument.RequireNotNull(builder, "builder");

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
