using System.Collections.Generic;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    internal class PurchasesRepository : Repository, IPurchasesRepository
    {
        public PurchasesRepository(DatabaseContext context) : base(context)
        {
        }

        public List<Purchase> GetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Save(int userId, int voucherId)
        {
            throw new System.NotImplementedException();
        }
    }
}