using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Persistence;
using RewardingSystem.Models;
using RewardingSystem.Filters;
using RewardingSystem.Application;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PointsController : BasicController
    {
        public PointsController(IUnitOfWork uow) : base(uow)
        {
        }
        [ServiceFilter(typeof(LoggedUserFilter))]
        [HttpGet]
        public IActionResult Get()
        {
            User loggedInUser = this.HttpContext.Items["user"] as User;
            List<Transaction> transactions = UnitOfWork.Transactions.Get(loggedInUser.Id);
            int points = transactions.Sum(t => t.Amount);
            return new JsonResult(new
            {
                Points = points
            });
        }


        [ServiceFilter(typeof(AdminFilter))]
        [HttpPost]
        public IActionResult Post([FromBody] dynamic request)
        {
            string email = request.Email;
            int amount = request.Amount;
            string description = request.Description;
            int refNum = request.ReferenceNumber;

            User user = UnitOfWork.Users.GetByEmail(email);
            int userId = user.Id;
            Transaction transaction = new Transaction()
            {
                Amount = amount,
                UserId = user.Id,
                Description = description,
                ReferenceNumber = refNum,
            };
            UnitOfWork.Transactions.Add(transaction);
            UnitOfWork.Save();
            return new EmptyResult();
        }
    }
}
