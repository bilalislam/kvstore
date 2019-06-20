using System.Collections.Generic;
using kvstore;
using kvstore.tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using serviceB.Controllers;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace serviceB.tests
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
            _client.SetValue(new Dictionary<string, object>
            {
                {"is-basket-enabled", 1}
            }).Wait();

            var controller = GetValuesController();

            //Act
            var result = controller.Get().Result;

            //Assert
            Assert.IsNotNull(result);
            var data = (List<object>) (result as OkObjectResult)?.Value;
            if (data == null) return;
            Assert.AreEqual(1, data.Count);
        }

        [Theory]
        [InlineData("is-basket-enabled")]
        public void Should_Be_Get_Is_Basket_Enabled(string isBasketEnabled)
        {
            //Arrange
            var controller = GetValuesController();

            //Act
            var result = controller.GetIsBasketEnabled(isBasketEnabled).Result;

            //Assert
            Assert.IsNotNull(result);
            var value = (result as OkObjectResult)?.Value;
            if (value == null) return;
            Assert.AreEqual(1, (long) value);
        }
    }
}