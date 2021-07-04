using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;
using Swashbuckle.AspNetCore.Annotations;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(LoggedUserFilter))]
    public class PurchasesController : UserAwareController
    {
        private PurchasesService PurchasesService { get; set; }

        public PurchasesController(PurchasesService service)
        {
            this.PurchasesService = service;
        }


        [HttpPost]
        [SwaggerOperation(summary: "Purchases a voucher [VoucherId] for the logged in user (User Token Required)")]
        public IActionResult Post([FromBody] dynamic request)
        {
            //Get Voucher
            int voucherId = request.VoucherId;
            this.PurchasesService.PurchaseVoucher(LoggedUser.Id, voucherId);
            return new EmptyResult();
        }
    }
}
