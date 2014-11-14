using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayMe.DomainModel.Customers;
using Rhino.Mocks;

namespace PayMe.Web.Resources
{
    [TestClass]
    public class CustomersControllerTest
    {
        [TestMethod]
        public void GetAll_ShouldReturnOne()
        {
            // Setup
            var mock = MockRepository.GenerateMock<ICustomerRepository>();
            mock.Expect(x => x.GetAll())
                .Return(new Customer[] 
                { 
                    new Customer() 
                    { 
                        Id = 1, 
                        Name = "Pipo" 
                    } 
                })
                .Repeat.Once();
            var subject = new CustomersController(mock);

            // Run test
            var result = subject.GetAll();

            // Post conditions
            mock.VerifyAllExpectations(); // doesn't work
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }
    }
}
