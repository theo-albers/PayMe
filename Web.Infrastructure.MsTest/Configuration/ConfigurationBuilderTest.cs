using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayMe.UnitTesting.Infrastructure;
using PayMe.Web.Infrastructure.Configuration;

namespace PayMe.Web.Infrastructure.MsTest.Configuration
{
    [TestClass]
    public class ConfigurationBuilderTest
    {
        [TestMethod]
        [ExpectContractFailure]
        public void Constructor_failOnNull()
        {
            var subject = new ConfigurationBuilder(null);
        }
    }

    
}
