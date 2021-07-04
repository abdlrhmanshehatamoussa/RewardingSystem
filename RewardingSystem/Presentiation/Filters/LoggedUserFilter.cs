using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Helpers;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RewardingSystem.Filters
{
    public class LoggedUserFilter : BasicAuthorizationFilter, IAuthorizationFilter, IOperationFilter
    {
        public LoggedUserFilter(IUnitOfWork uow) : base(uow)
        {
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = Globals.HEADER_TOKEN,
                In = ParameterLocation.Header,
                Description = "User Token",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
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