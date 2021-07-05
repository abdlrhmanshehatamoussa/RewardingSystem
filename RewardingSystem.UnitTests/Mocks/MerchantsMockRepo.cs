using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class MerchantsMockRepo : IMerchantsRepository
    {
        List<Merchant> list = new List<Merchant>()
        {
            Merchant1,
            Merchant2,
            Merchant3
        };

        public static Merchant Merchant1
        {
            get
            {
                return new Merchant()
                {
                    Id = 1,
                    Name = "Merchant 1",
                };
            }
        }

        public static Merchant Merchant2
        {
            get
            {
                return new Merchant()
                {
                    Id = 2,
                    Name = "Merchant 2",
                };
            }
        }

        public static Merchant Merchant3
        {
            get
            {
                return new Merchant()
                {
                    Id = 3,
                    Name = "Merchant 3",
                };
            }
        }

        public List<Merchant> GetAll()
        {
            return list;
        }
    }
}