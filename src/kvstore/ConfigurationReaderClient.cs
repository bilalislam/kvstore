using VaultSharp;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace kvstore
{
    public class ConfigurationReaderClient : IConfigurationReaderClient
    {
        private readonly IVaultClient _vaultClient;
        private readonly string _applicationName;

        public ConfigurationReaderClient(IVaultClient vaultClient, string applicationName)
        {
            _vaultClient = vaultClient;
            _applicationName = applicationName;
        }

        public async Task<object> GetValue(string key)
        {
            var application = await _vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(_applicationName);
            return application.Data.Data[key];
        }

        public async Task<List<object>> GetAllValues()
        {
            var application = await _vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(_applicationName);
            return application.Data.Data.Values.ToList();
        }
    }
}