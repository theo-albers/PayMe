using Autofac;
using PayMe.DomainModel.Customers;
using PayMe.Runtime.Contracts;

namespace PayMe.Web.Configuration.Dependencies
{
    public class EntityModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Argument.RequireNotNull(builder, "builder");

            builder.RegisterType<CustomerDbContext>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
