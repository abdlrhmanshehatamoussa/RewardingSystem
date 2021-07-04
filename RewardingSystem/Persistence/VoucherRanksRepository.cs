using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;
using System.Linq;

namespace RewardingSystem.Persistence
{
    public class VoucherRanksRepository : Repository, IVoucherRanksRepository
    {
        public VoucherRanksRepository(DatabaseContext context) : base(context)
        {
        }

        public List<VoucherRank> GetAll()
        {
            return this.Context.VoucherRanks.ToList();
        }
    }
}