using System.Threading.Tasks;
using kvstore;
using Microsoft.AspNetCore.Mvc;

namespace serviceB.Controllers
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

        // GET api/values/is-basket-enabled/${IS_BASKET_ENABLED}
        [HttpGet("is-basket-enabled/{key}")]
        public async Task<ActionResult> GetIsBasketEnabled(string key)
        {
            return Ok(await _configurationReaderClient.GetValue(key));
        }
    }
}