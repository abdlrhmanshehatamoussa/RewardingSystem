using System;
using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class PurchasesMockRepo : IPurchasesRepository
    {
        List<Purchase> list = new List<Purchase>() { };

        public List<Purchase> GetByUserId(int userId)
        {
            return this.list.Where(p => p.UserId == userId).ToList();
        }

        public bool HasPurchased(int userId, int voucherId)
        {
            return this.list.Any(p => p.UserId == userId && p.VoucherId == voucherId);
        }

        public void Save(int userId, int voucherId)
        {
            int maxId = this.list.Count + 1;
            this.list.Add(new Purchase()
            {
                Id = maxId + 1,
                UserId = userId,
                VoucherId = voucherId
            });
        }
    }
}