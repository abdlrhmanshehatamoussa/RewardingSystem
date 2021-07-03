using RewardingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace RewardingSystem.Persistence
{
    public class TransactionsRepository : Repository
    {
        public TransactionsRepository(DatabaseContext context) : base(context)
        {
        }

        public void Save(Transaction transaction)
        {
            if (transaction.Id == 0)
            {
                this.Context.Transactions.Add(transaction);
            }
            else
            {
                this.Context.Transactions.Update(transaction);
            }
            this.Context.SaveChanges();
        }

        public List<Transaction> Get(int userId)
        {
            return this.Context.Transactions.Where(t => t.UserId == userId).ToList();
        }
    }
}