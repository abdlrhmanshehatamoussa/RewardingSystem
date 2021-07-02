using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{

    public class AdminTokensRepository : Repository
    {
        public AdminTokensRepository(DatabaseContext context) : base(context)
        {
        }

        public string Create(int AdminId)
        {
            string token = Utils.GenerateToken();
            AdminToken AdminToken = new AdminToken()
            {
                Token = token,
                AdminId = AdminId
            };
            this.Context.AdminTokens.Add(AdminToken);
            this.Context.SaveChanges();
            return token;
        }
    }
}