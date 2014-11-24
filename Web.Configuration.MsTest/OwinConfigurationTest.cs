using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayMe.Web.Configuration
{
    [TestClass]
    public class OwinConfigurationTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_failOnNull()
        {
            var subject = new OwinConfiguration();

            // Run test
            subject.Configure(null);
        }
    }
}
