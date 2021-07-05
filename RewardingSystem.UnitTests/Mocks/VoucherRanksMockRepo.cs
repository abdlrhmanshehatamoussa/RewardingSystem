using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class VoucherRanksMockRepo : IVoucherRanksRepository
    {
        List<VoucherRank> list = new List<VoucherRank>()
        {
            Rank1,
            Rank2,
            Rank3
        };

        public static VoucherRank Rank1
        {
            get
            {
                return new VoucherRank()
                {
                    Id = 1,
                    Name = "Voucher Rank 1",
                    Points = 100
                };
            }
        }

        public static VoucherRank Rank2
        {
            get
            {
                return new VoucherRank()
                {
                    Id = 2,
                    Name = "Voucher Rank 2",
                    Points = 200
                };
            }
        }

        public static VoucherRank Rank3
        {
            get
            {
                return new VoucherRank()
                {
                    Id = 3,
                    Name = "Voucher Rank 3",
                    Points = 300
                };
            }
        }

        public List<VoucherRank> GetAll()
        {
            return list;
        }
    }
}