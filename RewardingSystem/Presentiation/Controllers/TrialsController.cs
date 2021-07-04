using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Filters;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(LoggedUserFilter))]
    public class TrialsController : BasicController
    {
        public TrialsController(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
