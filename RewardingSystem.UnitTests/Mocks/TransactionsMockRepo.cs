using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class TransactionsMockRepo : ITransactionsRepository
    {
        List<Transaction> list = new List<Transaction>() { };

        public void Add(Transaction transaction)
        {
            transaction.Id = list.Count + 1;
            this.list.Add(transaction);
        }

        public List<Transaction> Get(int userId)
        {
            return this.list.Where(u => u.UserId == userId).ToList();
        }
    }
}