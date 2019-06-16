using System.Collections.Generic;
using System.Threading.Tasks;

namespace kvstore
{
    public interface IConfigurationReaderClient
    {
        Task<object> GetValue(string key);
        Task<List<object>> GetAllValues();
    }
}