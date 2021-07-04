using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;

namespace RewardingSystem.Persistence
{
    public class VoucherRanksRepository : Repository, IVoucherRanksRepository
    {
        public VoucherRanksRepository(DatabaseContext context) : base(context)
        {
        }

        public List<VoucherRank> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}