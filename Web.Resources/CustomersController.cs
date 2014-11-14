using System.Collections.Generic;
using System.Web.Http;
using PayMe.DomainModel.Customers;

namespace PayMe.Web.Resources
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
