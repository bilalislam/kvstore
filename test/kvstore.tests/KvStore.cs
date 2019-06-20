using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace kvstore.tests
{
    public class KvStore : TestBase
    {
        private readonly IConfigurationReaderClient _client;

        public KvStore()
        {
            _client = BuildServiceProvider().GetService<IConfigurationReaderClient>();
        }

        [Fact]
        public void Should_Be_Alive()
        {
            var status = _client.GetStatus().Result.Initialized;
            Assert.IsTrue(status);
        }

        [Fact]
        public void Should_Be_Get_Given_Any_Value_of_Key_For_Service_A()
        {
            //Arrange
            _client.SetValue(new Dictionary<string, object>
            {
                {"site-name", "google.com.tr"},
                {"max-item-count", 50}
            }).Wait();


            //Act
            var siteName = _client.GetValue("site-name").Result;
            var maxItemCount = _client.GetValue("max-item-count").Result;

            //Assert
            Assert.AreEqual(siteName, "google.com.tr");
            Assert.AreEqual(maxItemCount, (Int64) 50);            
        }


        //kvstore policy checking
    }
}