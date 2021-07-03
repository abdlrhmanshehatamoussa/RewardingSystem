using System;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;

namespace RewardingSystem.Controllers
{
    public class BasicController : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }
        
        public BasicController(IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
        }
    }
}
