using System;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Controllers
{
    public class UserAwareController : Controller
    {
        protected User LoggedUser
        {
            get
            {
                User user;
                Object userObj;
                this.HttpContext.Items.TryGetValue(Globals.CONTEXT_ITEM_USER, out userObj);
                user = userObj as User;
                return user;
            }
        }

        public UserAwareController()
        {

        }
    }
}
