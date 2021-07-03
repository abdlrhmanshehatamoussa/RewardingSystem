using System;
using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Exceptions;

namespace RewardingSystem.Filters
{
    public class AdminFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (token != "admin")
            {
                throw new NotAuthorizedException();
            }
        }
    }
}