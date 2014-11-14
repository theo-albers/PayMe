using System.Data.Entity;

namespace PayMe.DomainModel.Customers
{
    public class CustomerDbContext : DbContext
    {
        public DbSet<Customer> Customers
        {
            get;
            set;
        }
    }
}
