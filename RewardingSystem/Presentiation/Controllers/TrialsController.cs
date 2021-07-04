using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(LoggedUserFilter))]
    public class TrialsController : UserAwareController
    {
        private TrialsService TrialsService { get; set; }
        public TrialsController(TrialsService service)
        {
            this.TrialsService = service;
        }

        [HttpPost]
        [SwaggerOperation(summary: "Applies a voucher [VoucherId] for the logged in user (User Token Required)")]
        public IActionResult Post([FromBody] dynamic request)
        {
            int voucherId = request.VoucherId;
            this.TrialsService.UseVoucher(LoggedUser.Id, voucherId);

            string fakeMessage = string.Format("Discount has been applied");
            return new JsonResult(new
            {
                Status = fakeMessage
            });
        }

    }
}
