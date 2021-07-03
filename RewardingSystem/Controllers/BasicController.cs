using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RewardingSystem.Persistence;

namespace RewardingSystem.Controllers
{
    public class BasicController:Controller
    {
        protected DatabaseContext Context{ get; set; }

        public BasicController(DatabaseContext context)
        {
            this.Context = context;
        }
    }
}
