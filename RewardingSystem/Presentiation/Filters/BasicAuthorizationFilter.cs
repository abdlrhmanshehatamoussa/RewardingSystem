using System;
using RewardingSystem.Application;

namespace RewardingSystem.Filters
{
    public class BasicAuthorizationFilter : Attribute
    {
        protected UsersService UsersService { get; set; }
        public BasicAuthorizationFilter(UsersService service)
        {
            this.UsersService = service;
        }
    }
}