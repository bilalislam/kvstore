using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace kvstore.tests
{
    [TestClass]
    public class KvStore : TestBase
    {
        private readonly IConfigurationReaderClient _client;

        public KvStore()
        {
            _client = BuildServiceProvider().GetService<IConfigurationReaderClient>();
        }

        [TestMethod]
        public void Should_Be_Alive()
        {
            var status = _client.GetStatus().Result.Initialized;
            Assert.IsTrue(status);
        }

        [TestMethod]
        [InlineData("site-name")]
        [InlineData("max-item-count")]
        public void Should_Be_Get_Given_Any_Value_of_Key_For_Service_A(string key, object value)
        {
            var status = _client.SetValue(new Dictionary<string, object>());
        }
    }
}