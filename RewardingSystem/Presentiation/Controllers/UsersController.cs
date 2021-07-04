using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using Swashbuckle.AspNetCore.Annotations;
namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : UserAwareController
    {
        private UsersService UsersService { get; set; }
        public UsersController(UsersService service)
        {
            this.UsersService = service;
        }


        //Get user informatiom by token
        [HttpGet("{token}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Get(string token)
        {
            var user = this.UsersService.GetUser(token);
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
            string token = UsersService.LoginUser(email, password);
            return new JsonResult(
                new
                {
                    Token = token,
                }
            );
        }
    }
}
