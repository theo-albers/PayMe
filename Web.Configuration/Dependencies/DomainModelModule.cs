using Autofac;
using PayMe.DomainModel.Customers;

namespace PayMe.Web.Configuration.Dependencies
{
    public class DomainModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
