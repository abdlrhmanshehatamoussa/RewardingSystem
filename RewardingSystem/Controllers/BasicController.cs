using RewardingSystem.Persistence;

namespace RewardingSystem.Controllers
{
    public class BasicController
    {
        protected DatabaseContext Context{ get; set; }
        public BasicController(DatabaseContext context)
        {
            this.Context = context;
        }
    }
}
