using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Persistence;
using RewardingSystem.Models;
using RewardingSystem.Filters;
using RewardingSystem.Application;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(summary: "Get number of points for the logged in users (User Token Required)")]
        public IActionResult Get()
        {
            List<Transaction> transactions = UnitOfWork.Transactions.Get(LoggedUser.Id);
            int points = transactions.Sum(t => t.Amount);
            return new JsonResult(new
            {
                Points = points
            });
        }


        [ServiceFilter(typeof(AdminFilter))]
        [HttpPost]
        [SwaggerOperation(summary: "Adds points for a given user [Email, Amount, Description, ReferenceNumber] (Admin Token Required)")]
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
