using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Helpers;
using System;
using Swashbuckle.AspNetCore.Annotations;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PingController : BasicController
    {
        public PingController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        [SwaggerOperation(summary: "Public endpoint to retrieve the version and environment of the system (No Tokens Required)")]
        public IActionResult Get()
        {
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
