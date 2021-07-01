using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RewardingSystem.Persistence;
using System.Collections.Generic;
using System.Linq;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MerchantsController : BasicController
    {
        public MerchantsController(IConfiguration config, DatabaseContext context) : base(config, context)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var merchants = Context.Merchants.ToList();
            return new JsonResult(merchants);
        }
    }
}
