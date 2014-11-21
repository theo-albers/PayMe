using System;
using System.Collections.Generic;
using System.Linq;

namespace PayMe.DomainModel.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository() 
            : this(new CustomerDbContext())
        {
        }

        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToArray();
            /*
            return new Customer[] 
            { 
                new Customer() 
                { 
                    Id = 1, 
                    Name = "Pipo" 
                } 
            };*/
        }
    }
}
