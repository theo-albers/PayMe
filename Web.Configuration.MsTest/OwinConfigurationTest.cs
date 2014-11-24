using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayMe.UnitTesting.Infrastructure;

namespace PayMe.Web.Configuration
{
    [TestClass]
    public class OwinConfigurationTest
    {
        [TestMethod]
        [ExpectContractFailure]
        public void Constructor_failOnNull()
        {
            var subject = new OwinConfiguration();

            // Run test
            subject.Configure(null);
        }
    }
}
