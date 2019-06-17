using System;
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
            try
            {
                var application = await _vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(_applicationName);
                return application.Data.Data[key];
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<object>> GetAllValues()
        {
            try
            {
                var application = await _vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync(_applicationName);
                return application.Data.Data.Values.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task SetValue(Dictionary<string, object> secrets)
        {
            try
            {
                await _vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync(_applicationName, secrets);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}