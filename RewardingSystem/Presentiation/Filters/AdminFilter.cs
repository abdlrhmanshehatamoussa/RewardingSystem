using System;
using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Filters
{
    public class AdminFilter : BasicAuthorizationFilter, IAuthorizationFilter
    {
        public AdminFilter(IUnitOfWork uow) : base(uow)
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers[Globals.HEADER_ADMIN_TOKEN];
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                Admin admin = this.UnitOfWork.Admins.GetByToken(token);
                if (admin != null)
                {
                    context.HttpContext.Items.Add("user", admin);
                    return;
                }
            }
            throw new NotAuthorizedException();
        }
    }
}