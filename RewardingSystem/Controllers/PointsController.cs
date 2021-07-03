using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RewardingSystem.Models;
using RewardingSystem.Persistence;
using RewardingSystem.Filters;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PointsController : BasicController
    {
        private TransactionsRepository TransactionsRepository { get; set; }
        private UsersRepository UsersRepository { get; set; }

        public PointsController(IConfiguration config, DatabaseContext context) : base(config, context)
        {
            this.TransactionsRepository = new TransactionsRepository(context);
            this.UsersRepository = new UsersRepository(context);
        }

        [LoggedUserFilter]
        [HttpGet]
        public IActionResult Get()
        {
            User loggedInUser = this.HttpContext.Items["user"] as User;
            List<Transaction> transactions = this.TransactionsRepository.Get(loggedInUser.Id);
            int points = transactions.Sum(t => t.Amount);
            return new JsonResult(new
            {
                Points = points
            });
        }


        [AdminFilter]
        [HttpPost]
        public IActionResult Post([FromBody] dynamic request)
        {
            string email = request.Email;
            int amount = request.Amount;
            string description = request.Description;
            int refNum = request.ReferenceNumber;

            User user = this.UsersRepository.GetByEmail(email);
            int userId = user.Id;
            Transaction transaction = new Transaction()
            {
                Amount = amount,
                UserId = user.Id,
                Description = description,
                ReferenceNumber = refNum,
            };
            this.TransactionsRepository.Save(transaction);
            return new EmptyResult();
        }
    }
}