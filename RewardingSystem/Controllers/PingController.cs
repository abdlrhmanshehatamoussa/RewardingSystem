using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RewardingSystem.Helpers;
using RewardingSystem.Persistence;
using System;
using System.Linq;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PingController : BasicController
    {
        public PingController(DatabaseContext context) : base(context)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var merchants = Context.Merchants.ToList();
            var version = AppSettings.Instance.Version;
            var environment = AppSettings.Instance.Environment;
            var timestamp = string.Format("{0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            var response = new
            {
                Version = version,
                TimeStamp = timestamp,
                Environment = environment
            };
            return new JsonResult(response);
        }
    }

}
