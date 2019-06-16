using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kvstore
{
    public static class KvStoreConfigurationExtensions
    {
        /// <summary>
        /// It creates singleton kvstore config per each service therefore Its avoided concurrency problems
        /// about all client app ...
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        public static void AddKvStore(this IServiceCollection services, IConfiguration config)
        {
            var options = GetOptions(config);

            var client = new KvStoreClientWrapper(options).GetClient();
            services.AddSingleton<IConfigurationReaderClient>(
                new ConfigurationReaderClient(client, options.ApplicationName));
        }

        private static KvOptions GetOptions(IConfiguration config)
        {
            var options = new KvOptions();

            if (config.Get<KvOptions>().Server == null)
            {
                config.Bind("KvOptions", options);
            }

            if (string.IsNullOrEmpty(options.Server)) throw new ArgumentNullException(nameof(options.Server));

            return options;
        }
    }
}