using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(LoggedUserFilter))]
    public class PurchasesController : BasicController
    {
        public PurchasesController(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
