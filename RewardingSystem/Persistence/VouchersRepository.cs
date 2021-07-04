using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;

namespace RewardingSystem.Persistence
{
    public class VouchersRepository : Repository, IVouchersRepository
    {
        public VouchersRepository(DatabaseContext context) : base(context)
        {
        }


        public List<Voucher> GetByRank(int rankId)
        {
            throw new System.NotImplementedException();
        }


        public List<Voucher> GetByType(int typeId)
        {
            throw new System.NotImplementedException();
        }
    }
}