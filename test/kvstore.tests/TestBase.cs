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
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json")
                    .AddEnvironmentVariables();

            var configuration = builder.Build();
            var services = new ServiceCollection();

            services.AddKvStore(configuration);
            services.Configure<KvOptions>(configuration.GetSection("KvOptions"));

            return services.BuildServiceProvider();
        }
    }
}