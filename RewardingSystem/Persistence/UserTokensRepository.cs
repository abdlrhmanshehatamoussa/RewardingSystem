using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    public class UserTokensRepository : Repository
    {
        public UserTokensRepository(DatabaseContext context) : base(context)
        {
        }

        public string Create(int userId)
        {
            string token = Utils.GenerateToken();
            UserToken userToken = new UserToken()
            {
                Token = token,
                UserId = userId
            };
            this.Context.UserTokens.Add(userToken);
            this.Context.SaveChanges();
            return token;
        }
    }
}