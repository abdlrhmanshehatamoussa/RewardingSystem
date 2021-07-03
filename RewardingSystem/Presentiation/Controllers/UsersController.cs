using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;
using RewardingSystem.Persistence;
using System;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : BasicController
    {
        private IUsersRepository UsersRepository;
        private IUserTokensRepository UserTokensRepository;

        public UsersController(DatabaseContext context) : base(context)
        {
            this.UsersRepository = new UsersRepository(context);
            this.UserTokensRepository = new UserTokensRepository(context);
        }

        //Get user informatiom by token
        [HttpGet("{token}")]
        public IActionResult Get(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Missing Token");
            }
            var user = this.UsersRepository.GetByToken(token);
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
        public IActionResult UsersLogin([FromBody] dynamic request)
        {
            string email = request.Email;
            string password = request.Password;
            User user = UsersRepository.GetByEmail(email);
            if (user == null || user.Password != password)
            {
                throw new FailedLoginException("Invalid Credentials");
            }
            string token = this.UserTokensRepository.Add(user.Id);
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
