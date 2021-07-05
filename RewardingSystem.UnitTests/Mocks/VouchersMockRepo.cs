using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class VouchersMockRepo : IVouchersRepository
    {
        List<Voucher> list;

        public VouchersMockRepo()
        {
            this.list = new List<Voucher>()
            {
               Voucher1,
               Voucher2,
               Voucher3,
            };
        }
        public Voucher GetById(int voucherId)
        {
            return this.list.FirstOrDefault(v => v.Id == voucherId);
        }

        public List<Voucher> GetByRank(int rankId)
        {
            return this.list.Where(v => v.VoucherRankId == rankId).ToList();
        }

        public List<Voucher> GetByType(int typeId)
        {
            return this.list.Where(v => v.VoucherTypeId == typeId).ToList();
        }






        public static Voucher Voucher1
        {
            get
            {
                return new Voucher()
                {
                    Id = 1,
                    Title = "Voucher 1",
                    Code = "Code 1",
                    Description = "Desc 1",
                    Limit = 1,
                    MerchantId = 1,
                    Merchant = MerchantsMockRepo.Merchant1,
                    VoucherRankId = 1,
                    VoucherTypeId = 1,
                    VoucherRank = VoucherRanksMockRepo.Rank1,
                    VoucherType = VoucherTypesMockRepo.Type1
                };
            }
        }

        public static Voucher Voucher2
        {
            get
            {
                return new Voucher()
                {
                    Id = 2,
                    Title = "Voucher 2",
                    Code = "Code 2",
                    Description = "Desc 2",
                    Limit = 2,
                    MerchantId = 2,
                    Merchant = MerchantsMockRepo.Merchant2,
                    VoucherRankId = 2,
                    VoucherTypeId = 2,
                    VoucherRank = VoucherRanksMockRepo.Rank2,
                    VoucherType = VoucherTypesMockRepo.Type2
                };
            }
        }

        public static Voucher Voucher3
        {
            get
            {
                return new Voucher()
                {
                    Id = 3,
                    Title = "Voucher 3",
                    Code = "Code 3",
                    Description = "Desc 3",
                    Limit = 3,
                    MerchantId = 3,
                    Merchant = MerchantsMockRepo.Merchant3,
                    VoucherRankId = 3,
                    VoucherTypeId = 3,
                    VoucherRank = VoucherRanksMockRepo.Rank3,
                    VoucherType = VoucherTypesMockRepo.Type3
                };
            }
        }
    }
}