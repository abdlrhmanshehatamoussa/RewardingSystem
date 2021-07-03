using System;
using RewardingSystem.Application;

namespace RewardingSystem.Filters
{
    public class BasicAuthorizationFilter : Attribute
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        public BasicAuthorizationFilter(IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
        }
    }
}