using System;
using System.Collections.Generic;
using kvstore;
using kvstore.tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using serviceA.Controllers;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace serviceA.tests
{
    public class ValuesControllerTest : TestBase
    {
        private readonly IConfigurationReaderClient _client;

        public ValuesControllerTest()
        {
            _client = BuildServiceProvider().GetService<IConfigurationReaderClient>();
        }

        private ValuesController GetValuesController()
        {
            var controller = new ValuesController(_client);
            return controller;
        }

        [Fact]
        public void Should_Be_Get_All_Values()
        {
            //Arrange
            var controller = GetValuesController();

            //Act
            var result = controller.Get().Result;

            //Assert
            Assert.IsNotNull(result);
            var data = (List<object>) (result as OkObjectResult)?.Value;
            if (data == null) return;
            Assert.AreEqual(2, data.Count);
        }

        [Theory]
        [InlineData("site-name")]
        public void Should_Be_Get_Site_Name(string siteName)
        {
            //Arrange
            var controller = GetValuesController();

            //Act
            var result = controller.GetSiteName(siteName).Result;

            //Assert
            Assert.IsNotNull(result);
            var data = (string) (result as OkObjectResult)?.Value;
            if (data == null) return;
            Assert.AreEqual("google.com.tr", data);
        }

        [Theory]
        [InlineData("max-item-count")]
        public void Should_Be_Get_Max_Item_Count(string maxItemCount)
        {
            //Arrange
            var controller = GetValuesController();

            //Act
            var result = controller.GetMaxItemCount(maxItemCount).Result;

            //Assert
            Assert.IsNotNull(result);
            var value = (result as OkObjectResult)?.Value;
            if (value == null) return;
            var data = (Int64) value;
            Assert.AreEqual(50, data);
        }
    }
}