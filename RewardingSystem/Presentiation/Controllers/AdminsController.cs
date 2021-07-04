using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AdminsController : UserAwareController
    {
        private UsersService UsersService { get; set; }
        public AdminsController(UsersService service)
        {
            this.UsersService = service;
        }

        //Get Admin informatiom by token
        [HttpGet("{token}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get(string token)
        {
            Admin admin = this.UsersService.GetAdmin(token);
            return new JsonResult(
                new
                {
                    UserName = admin.UserName,
                }
            );
        }

        //Exchange Admin credentials for a token
        [HttpPost("login", Name = "AdminsLogin")]
        [SwaggerOperation(summary: "Exchanges admin credentials ['UserName', 'Password'] for an admin token (No Tokens Required)")]
        public IActionResult AdminsLogin([FromBody] dynamic request)
        {
            string username = request.UserName;
            string password = request.Password;
            string token = this.UsersService.LoginAdmin(username, password);
            return new JsonResult(
                new
                {
                    Token = token,
                }
            );
        }
    }
}
