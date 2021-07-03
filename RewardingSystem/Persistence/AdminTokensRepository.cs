using RewardingSystem.Helpers;
using RewardingSystem.Models;
using RewardingSystem.Application;

namespace RewardingSystem.Persistence
{

    public class AdminTokensRepository : Repository, IAdminTokensRepository
    {
        public AdminTokensRepository(DatabaseContext context) : base(context)
        {
        }

        public string Add(int AdminId)
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