using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;

namespace RewardingSystem.Persistence
{
    public class VoucherTypesRepository : Repository, IVoucherTypesRepository
    {
        public VoucherTypesRepository(DatabaseContext context) : base(context)
        {
        }

        public List<VoucherType> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}