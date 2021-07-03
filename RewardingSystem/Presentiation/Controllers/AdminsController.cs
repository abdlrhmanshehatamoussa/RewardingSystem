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
    public class AdminsController : BasicController
    {
        public AdminsController(IUnitOfWork uow) : base(uow)
        {
        }

        //Get Admin informatiom by token
        [HttpGet("{token}")]
        public IActionResult Get(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Missing Token");
            }
            var admin = this.UnitOfWork.Admins.GetByToken(token);
            if (admin == null)
            {
                throw new Exception("Invalid Token");
            }
            return new JsonResult(
                new
                {
                    UserName = admin.UserName,
                }
            );
        }

        //Exchange Admin credentials for a token
        [HttpPost("login", Name = "AdminsLogin")]
        public IActionResult AdminsLogin([FromBody] dynamic request)
        {
            string username = request.UserName;
            string password = request.Password;
            Admin admin = this.UnitOfWork.Admins.GetByUserName(username);
            if (admin == null || admin.Password != password)
            {
                throw new FailedLoginException("Invalid Credentials");
            }
            string token = this.UnitOfWork.AdminsTokens.Add(admin.Id);
            this.UnitOfWork.Save();
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
