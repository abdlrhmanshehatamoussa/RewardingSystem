using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    internal class PurchasesRepository : Repository, IPurchasesRepository
    {
        public PurchasesRepository(DatabaseContext context) : base(context)
        {
        }

        public List<Purchase> GetByUserId(int userId)
        {
            return this.Context.Purchases.Include(p => p.Voucher).Where(p => p.UserId == userId).ToList();
        }

        public bool HasPurchased(int userId, int voucherId)
        {
            return this.Context.Purchases.Any(p => p.UserId == userId && p.VoucherId == voucherId);
        }

        public void Save(int userId, int voucherId)
        {
            //Get User
            Purchase voucher = new Purchase()
            {
                UserId = userId,
                VoucherId = voucherId
            };
            this.Context.Purchases.Add(voucher);
        }
    }
}