using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    internal class MerchantsRepository : Repository, IMerchantsRepository
    {
        public MerchantsRepository(DatabaseContext context) : base(context)
        {
        }

        public List<Merchant> GetAll()
        {
            return this.Context.Merchants.ToList();
        }
    }
}