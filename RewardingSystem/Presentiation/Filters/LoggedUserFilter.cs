using System;
using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;

namespace RewardingSystem.Filters
{
    public class LoggedUserFilter : BasicAuthorizationFilter, IAuthorizationFilter
    {
        public LoggedUserFilter(IUnitOfWork uow) : base(uow)
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["token"];
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                User user = this.UnitOfWork.Users.GetByToken(token);
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