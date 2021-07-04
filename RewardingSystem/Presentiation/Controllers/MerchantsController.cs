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
    public class MerchantsController : BasicController
    {
        public MerchantsController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        [SwaggerOperation(summary: "Lists all the merchants (Admin Token Required)")]
        public IActionResult Get()
        {
            List<Merchant> merchants = UnitOfWork.Merchants.GetAll();
            return new JsonResult(merchants);
        }
    }
}
