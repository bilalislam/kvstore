using System.Collections.Generic;
using System.Threading.Tasks;
using VaultSharp.V1.Commons;
using VaultSharp.V1.SystemBackend;

namespace kvstore
{
    public interface IConfigurationReaderClient
    {
        Task<object> GetValue(string key);
        Task<List<object>> GetAllValues();
        Task SetValue(Dictionary<string, object> secrets);
        Task<HealthStatus> GetStatus();
        Task<Secret<Policy>> GetPolicy(string policyName);
    }
}