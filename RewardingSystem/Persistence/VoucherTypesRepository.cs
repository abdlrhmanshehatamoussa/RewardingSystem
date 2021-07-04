using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;
using System.Linq;

namespace RewardingSystem.Persistence
{
    public class VoucherTypesRepository : Repository, IVoucherTypesRepository
    {
        public VoucherTypesRepository(DatabaseContext context) : base(context)
        {
        }

        public List<VoucherType> GetAll()
        {
            return this.Context.VoucherTypes.ToList();
        }
    }
}