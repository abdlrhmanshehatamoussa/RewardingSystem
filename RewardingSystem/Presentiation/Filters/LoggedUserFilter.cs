using System;
using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;

namespace RewardingSystem.Filters
{
    public class LoggedUserFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                //To be replaced
                User user = new User()
                {
                    Id = 1
                };
                if (user != null)
                {
                    context.HttpContext.Items.Add("user", user);
                    return;
                }
            }
            throw new NotAuthorizedException();
        }
    }
}