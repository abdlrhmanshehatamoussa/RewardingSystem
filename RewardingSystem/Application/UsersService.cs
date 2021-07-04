using System;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class UsersService : CRUDService
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public User GetUser(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Missing Token");
            }
            User user = UnitOfWork.Users.GetByToken(token);
            if (user == null)
            {
                throw new Exception("Invalid Token");
            }
            return user;
        }

        public string LoginUser(string email, string password)
        {
            User user = UnitOfWork.Users.GetByEmail(email);
            if (user == null || user.Password != password)
            {
                throw new FailedLoginException("Invalid Credentials");
            }
            string token = UnitOfWork.UserTokens.Add(user.Id);
            UnitOfWork.Save();
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new FailedLoginException("Failed to create token");
            }
            return token;
        }

        public Admin GetAdmin(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new Exception("Missing Token");
            }
            Admin admin = this.UnitOfWork.Admins.GetByToken(token);
            if (admin == null)
            {
                throw new Exception("Invalid Token");
            }
            return admin;
        }

        public string LoginAdmin(string username, string password)
        {
            Admin admin = this.UnitOfWork.Admins.GetByUserName(username);
            if (admin == null || admin.Password != password)
            {
                throw new FailedLoginException("Invalid Credentials");
            }
            string token = this.UnitOfWork.AdminsTokens.Add(admin.Id);
            this.UnitOfWork.Save();
            if (string.IsNullOrWhiteSpace(token))
            {
                throw new FailedLoginException("Failed to create token");
            }
            return token;
        }
    }
}
