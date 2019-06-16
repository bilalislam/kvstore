using System.Threading.Tasks;
using kvstore;
using Microsoft.AspNetCore.Mvc;

namespace serviceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfigurationReaderClient _configurationReaderClient;

        public ValuesController(IConfigurationReaderClient configurationReaderClient)
        {
            _configurationReaderClient = configurationReaderClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _configurationReaderClient.GetAllValues());
        }

        // GET api/values/site-name/${SITE_NAME}
        [HttpGet("site-name/{key}")]
        public async Task<ActionResult> GetSiteName(string key)
        {
            return Ok(await _configurationReaderClient.GetValue(key));
        }

        // GET api/values/max-item-count/${MAX_ITEM_COUNT}
        [HttpGet("max-item-count/{key}")]
        public async Task<ActionResult> GetMaxItemCount(string key)
        {
            return Ok(await _configurationReaderClient.GetValue(key));
        }
    }
}