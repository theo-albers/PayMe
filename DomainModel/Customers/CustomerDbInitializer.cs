using System.Data.Entity;

namespace PayMe.DomainModel.Customers
{
    public class CustomerDbInitializer : DropCreateDatabaseAlways<CustomerDbContext>
    {
        protected override void Seed(CustomerDbContext context)
        {
            context.Customers.Add(new Customer() 
            { 
                Id = 1, 
                Name = "Pipo"
            });

            base.Seed(context);
        }
    }
}
