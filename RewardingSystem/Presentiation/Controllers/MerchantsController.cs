using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Models;
using RewardingSystem.Filters;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Annotations;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(AdminFilter))]
    public class MerchantsController : UserAwareController
    {
        private MerchantsService MerchantsService { get; set; }
        public MerchantsController(MerchantsService s)
        {
            this.MerchantsService = s;
        }

        [HttpGet]
        [SwaggerOperation(summary: "Lists all the merchants (Admin Token Required)")]
        public IActionResult Get()
        {
            List<Merchant> merchants = this.MerchantsService.GetAll();
            return new JsonResult(merchants);
        }
    }
}
