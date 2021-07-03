using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;
using System.Linq;
namespace RewardingSystem.Persistence
{
    public class TransactionsRepository : Repository, ITransactionsRepository
    {
        public TransactionsRepository(DatabaseContext context) : base(context)
        {
        }

        public void Add(Transaction transaction)
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