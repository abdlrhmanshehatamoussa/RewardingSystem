using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using System;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MerchantsController:BasicController
    {
        public MerchantsController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
    }
}
