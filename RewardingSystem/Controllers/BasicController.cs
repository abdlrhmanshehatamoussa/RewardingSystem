using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RewardingSystem.Persistence;

namespace RewardingSystem.Controllers
{
    public class BasicController:Controller
    {
        protected DatabaseContext Context{ get; set; }
        protected IConfiguration Configurations{ get; set; }

        public BasicController(IConfiguration config, DatabaseContext context)
        {
            this.Context = context;
            this.Configurations = config;
        }
    }
}
