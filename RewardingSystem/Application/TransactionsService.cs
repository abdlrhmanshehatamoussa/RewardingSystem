using System;
using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class TransactionsService : CRUDService
    {
        public TransactionsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public int GetPointsForUser(int userId)
        {
            return GetTransactionsForUser(userId).Sum(t => t.Amount);
        }
        public List<Transaction> GetTransactionsForUser(int userId)
        {
            return this.UnitOfWork.Transactions.Get(userId);
        }

        public void CreateTransaction(string email, Transaction transaction)
        {
            User user = UnitOfWork.Users.GetByEmail(email);
            transaction.UserId = user.Id;
            UnitOfWork.Transactions.Add(transaction);
            UnitOfWork.Save();
        }
    }
}
