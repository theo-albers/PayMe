using System;
using System.Collections.Generic;
using System.Linq;
using PayMe.Runtime.Contracts;

namespace PayMe.DomainModel.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _context;

        public CustomerRepository(CustomerDbContext context)
        {
            Argument.RequireNotNull(context, "context");

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
