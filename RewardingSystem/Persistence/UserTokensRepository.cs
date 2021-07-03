using RewardingSystem.Helpers;
using RewardingSystem.Models;
using RewardingSystem.Application;
namespace RewardingSystem.Persistence
{
    public class UserTokensRepository : Repository, IUserTokensRepository
    {
        public UserTokensRepository(DatabaseContext context) : base(context)
        {
        }

        public string Add(int userId)
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