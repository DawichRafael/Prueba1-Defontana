using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhylogeneticTreeApi.DataAccess;
using PhylogeneticTreeApi.Entity.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhylogeneticTreeApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeData _homeData;

        public HomeController(ILogger<HomeController> logger, IHomeData homeData)
        {
            _logger = logger;
            _homeData = homeData;
        }

        [HttpGet]
        [Route("getTyphologenetic")]
        public async Task<IActionResult> getTyphologenetic()
        {
            try
            {
               Branches[] trees = new Branches[] { };

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://test.defontana.com/"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var das = JObject.Parse(apiResponse)["data"];
                        var other = JsonConvert.SerializeObject(das);
                        var sd = das.ToObject<Branches[]>();
                        trees = JsonConvert.DeserializeObject<Branches[]>(other);
                    }
                }
                return Ok(_homeData.getTyphologenetic(trees));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");

                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
