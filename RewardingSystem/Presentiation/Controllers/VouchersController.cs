using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    [ServiceFilter(typeof(LoggedUserFilter))]
    public class VouchersController : UserAwareController
    {
        private VouchersService VouchersService { get; set; }

        public VouchersController(VouchersService service)
        {
            this.VouchersService = service;
        }


        [HttpGet]
        [SwaggerOperation(summary: "Get the available vouchers for the logged in user based on the number of points and the voucher ranks (Silver, Bronze, Gold, Platinum) (User Token Required)")]
        public IActionResult Get()
        {
            List<VoucherSummary> results = this.VouchersService.GetForUser(LoggedUser.Id);
            return new JsonResult(results);
        }
    }
}
