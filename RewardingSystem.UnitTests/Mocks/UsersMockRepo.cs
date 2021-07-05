using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class UsersMockRepo : IUsersRepository
    {
        List<User> list = new List<User>()
        {
            User1
        };

        public static User User1
        {
            get
            {
                return new User()
                {
                    Id = 1,
                    Name = "User 1",
                    Email = "email1@gmail.com",
                    Password = "123456"
                };
            }
        }

        public User GetByEmail(string email)
        {
            return this.list.FirstOrDefault(u => u.Email == email);
        }

        public User GetByToken(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}