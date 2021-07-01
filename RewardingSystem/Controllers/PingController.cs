using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public PingController(IConfiguration config, DatabaseContext context) : base(config, context)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var merchants = Context.Merchants.ToList();
            var version = this.Configurations.GetValue<string>("AppSettings:Version");
            var timestamp = string.Format("{0} - {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
            var response = new PingResponse(version, timestamp);
            return new JsonResult(response);
        }



        private class PingResponse
        {
            public string Version { get; set; }
            public string TimeStamp { get; set; }
            public PingResponse(string v, string t)
            {
                this.Version = v;
                this.TimeStamp = t;
            }
        }
    }

}
