using System;
using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace Tests
{
    public class TrialsMockRepo : ITrialsRepository
    {
        private List<Trial> list = new List<Trial>();

        public List<Trial> GetByUserId(int userId)
        {
            return this.list.Where(t => t.UserId == userId).ToList();
        }

        public List<Trial> GetByVoucherId(int userId, int voucherId)
        {
            return this.list.Where(t => t.UserId == userId && t.VoucherId == voucherId).ToList();
        }

        public void Save(int userId, int voucherId)
        {
            this.list.Add(new Trial()
            {
                Id = list.Count + 1,
                UserId = userId,
                VoucherId = voucherId
            });
        }
    }
}