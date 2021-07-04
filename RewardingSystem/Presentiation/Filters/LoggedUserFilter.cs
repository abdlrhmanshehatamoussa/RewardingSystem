using System;
using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Helpers;
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
            string token = context.HttpContext.Request.Headers[Globals.HEADER_TOKEN];
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                User user = this.UnitOfWork.Users.GetByToken(token);
                if (user != null)
                {
                    context.HttpContext.Items.Add(Globals.CONTEXT_ITEM_USER, user);
                    return;
                }
            }
            throw new NotAuthenticatedException();
        }
    }
}