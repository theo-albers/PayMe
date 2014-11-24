using System.Collections.Generic;
using System.Web.Http;
using PayMe.DomainModel.Customers;
using PayMe.Runtime.Contracts;

namespace PayMe.Web.Resources
{
    public class CustomersController : ApiController
    {
        private readonly ICustomerRepository _repository;

        public CustomersController(ICustomerRepository repository)
        {
            Argument.RequireNotNull(repository, "repository");

            _repository = repository;
        }

        // GET api/<controller> 
        [HttpGet] 
        public IEnumerable<Customer> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
