using System.Collections.Generic;

namespace PayMe.DomainModel.Customers
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
    }
}
