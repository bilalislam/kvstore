using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kvstore.tests
{
    public class TestBase
    {
        protected ServiceProvider BuildServiceProvider()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();
            var services = new ServiceCollection();

            services.AddKvStore(configuration);          

            return services.BuildServiceProvider();
        }
    }
}