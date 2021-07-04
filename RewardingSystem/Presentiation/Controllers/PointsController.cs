using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Models;
using RewardingSystem.Filters;
using RewardingSystem.Application;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PointsController : UserAwareController
    {
        private TransactionsService TransactionsService { get; set; }
        public PointsController(TransactionsService service)
        {
            this.TransactionsService = service;
        }


        [ServiceFilter(typeof(LoggedUserFilter))]
        [HttpGet]
        [SwaggerOperation(summary: "Get number of points for the logged in users (User Token Required)")]
        public IActionResult Get()
        {
            int points = TransactionsService.GetPointsForUser(LoggedUser.Id);
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
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(description) || refNum == 0 || amount == 0)
            {
                throw new Exception("Please fill the input parameters properly");
            }
            Transaction transaction = new Transaction()
            {
                Amount = amount,
                Description = description,
                ReferenceNumber = refNum,
            };
            this.TransactionsService.CreateTransaction(email, transaction);
            return new EmptyResult();
        }
    }
}
