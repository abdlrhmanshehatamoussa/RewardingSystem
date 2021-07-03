using Microsoft.EntityFrameworkCore;
using RewardingSystem.Models;
using System.Linq;
using RewardingSystem.Application;

namespace RewardingSystem.Persistence
{
    public class UsersRepository : Repository, IUsersRepository
    {
        public UsersRepository(DatabaseContext context) : base(context)
        {
        }

        public User GetByToken(string token)
        {
            var userToken = this.Context.UserTokens.Include(t => t.User).FirstOrDefault(t => t.Token == token);
            return userToken?.User;
        }

        public User GetByEmail(string email)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }
    }
}