using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class VoucherTypesMockRepo : IVoucherTypesRepository
    {
        List<VoucherType> list = new List<VoucherType>()
        {
            Type1,
            Type2,
            Type3
        };

        public static VoucherType Type1
        {
            get
            {
                return new VoucherType()
                {
                    Id = 1,
                    Name = "Voucher Type 1",
                    Discount = 10
                };
            }
        }

        public static VoucherType Type2
        {
            get
            {
                return new VoucherType()
                {
                    Id = 2,
                    Name = "Voucher Type 2",
                    Discount = 20
                };
            }
        }

        public static VoucherType Type3
        {
            get
            {
                return new VoucherType()
                {
                    Id = 3,
                    Name = "Voucher Type 3",
                    Discount = 30
                };
            }
        }

        public List<VoucherType> GetAll()
        {
            return list;
        }
    }
}