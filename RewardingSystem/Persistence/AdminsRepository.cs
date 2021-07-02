using Microsoft.EntityFrameworkCore;
using RewardingSystem.Models;
using System;
using System.Linq;

namespace RewardingSystem.Persistence
{
    public class AdminsRepository : Repository
    {
        public AdminsRepository(DatabaseContext context) : base(context)
        {
        }

        public Admin GetByToken(string token)
        {
            var AdminToken = this.Context.AdminTokens.Include(t => t.Admin).FirstOrDefault(t => t.Token == token);
            return AdminToken?.Admin;
        }

        public Admin GetByUserName(string username)
        {
            var Admin = this.Context.Admins.FirstOrDefault(u => u.UserName == username);
            return Admin;
        }
    }
}