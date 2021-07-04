using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;
using RewardingSystem.Persistence;
using Swashbuckle.AspNetCore.Annotations;
using System;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : BasicController
    {
        public UsersController(IUnitOfWork uow) : base(uow)
        {
        }

        //Get user informatiom by token
        [HttpGet("{token}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Missing Token");
            }
            var user = UnitOfWork.Users.GetByToken(token);
            if (user == null)
            {
                throw new Exception("Invalid Token");
            }
            return new JsonResult(
                new
                {
                    Email = user.Email,
                    Name = user.Name,
                }
            );
        }

        //Exchange user credentials for a token
        [HttpPost("login", Name = "UsersLogin")]
        [SwaggerOperation(summary: "Exchanges user credentials [Email, Password] for a user token (No Token Required)")]
        public IActionResult UsersLogin([FromBody] dynamic request)
        {
            string email = request.Email;
            string password = request.Password;
            User user = UnitOfWork.Users.GetByEmail(email);
            if (user == null || user.Password != password)
            {
                throw new FailedLoginException("Invalid Credentials");
            }
            string token = UnitOfWork.UserTokens.Add(user.Id);
            UnitOfWork.Save();
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new FailedLoginException("Failed to create token");
            }
            return new JsonResult(
                new
                {
                    Token = token,
                }
            );
        }
    }
}
