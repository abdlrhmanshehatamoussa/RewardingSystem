using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Models;
using RewardingSystem.Filters;
using System.Collections.Generic;

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
        public IActionResult Get()
        {
            List<Merchant> merchants = UnitOfWork.Merchants.GetAll();
            return new JsonResult(merchants);
        }
    }
}
