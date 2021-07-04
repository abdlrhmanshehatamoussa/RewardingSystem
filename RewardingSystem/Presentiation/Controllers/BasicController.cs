using System;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Controllers
{
    public class BasicController : Controller
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        protected User LoggedUser
        {
            get
            {
                return this.HttpContext.Items[Globals.CONTEXT_ITEM_USER] as User;
            }
        }

        public BasicController(IUnitOfWork uow)
        {
            this.UnitOfWork = uow;
        }
    }
}
