using System;
using System.Data.Entity;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayMe.DomainModel.Customers
{
    [TestClass]
    public class CustomerRepositoryIntegrationTest
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext context)
        {
            Database.SetInitializer<CustomerDbContext>(new CustomerDbInitializer());
        }

        [TestMethod]
        public void GetAll_ShouldReturnOne()
        {
            // Setup
            var context = new CustomerDbContext();
            var subject = new CustomerRepository(context);

            // Run test
            var result = subject.GetAll();

            // Post conditions
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
        }
    }
}
