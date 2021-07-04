using Microsoft.AspNetCore.Mvc.Filters;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Helpers;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace RewardingSystem.Filters
{
    public class AdminFilter : BasicAuthorizationFilter, IAuthorizationFilter, IOperationFilter
    {
        public AdminFilter(UsersService service) : base(service)
        {
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = Globals.HEADER_ADMIN_TOKEN,
                In = ParameterLocation.Header,
                Description = "Admin Token",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers[Globals.HEADER_ADMIN_TOKEN];
            if (string.IsNullOrWhiteSpace(token) == false)
            {
                Admin admin = this.UsersService.GetAdmin(token);
                if (admin != null)
                {
                    return;
                }
            }
            throw new NotAuthorizedException();
        }
    }
}