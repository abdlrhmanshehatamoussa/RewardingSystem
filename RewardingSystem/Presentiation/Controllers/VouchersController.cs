using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;

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
            List<Voucher> vouchers = this.VouchersService.GetForUser(LoggedUser.Id);
            var results = vouchers.Select(v => new
            {
                Id = v.Id,
                Title = v.Title,
                Description = v.Description,
                Rank = v.VoucherRank.Name,
                Type = v.VoucherType.Name,
                Limit = v.Limit,
                Merchant = v.Merchant.Name
            });
            return new JsonResult(results);
        }
    }
}
