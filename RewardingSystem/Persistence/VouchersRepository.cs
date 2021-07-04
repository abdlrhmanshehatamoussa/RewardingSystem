using RewardingSystem.Models;
using RewardingSystem.Application;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RewardingSystem.Persistence
{
    public class VouchersRepository : Repository, IVouchersRepository
    {
        public VouchersRepository(DatabaseContext context) : base(context)
        {
        }


        public List<Voucher> GetByRank(int rankId)
        {
            return this.Context.Vouchers.Include(v => v.Merchant).Include(v => v.VoucherType).Where(v => v.VoucherRankId == rankId).ToList();
        }


        public List<Voucher> GetByType(int typeId)
        {
            return this.Context.Vouchers.Include(v => v.Merchant).Include(v => v.VoucherRank).Where(v => v.VoucherTypeId == typeId).ToList();
        }

        Voucher IVouchersRepository.GetById(int voucherId)
        {
            return this.Context.Vouchers.Include(v=>v.VoucherRank).Include(v=>v.VoucherType).FirstOrDefault(v => v.Id == voucherId);
        }
    }
}