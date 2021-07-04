using System.Collections.Generic;
using RewardingSystem.Application;
using RewardingSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RewardingSystem.Persistence
{
    internal class TrialsRepository : Repository, ITrialsRepository
    {
        public TrialsRepository(DatabaseContext context) : base(context)
        {
        }

        public List<Trial> GetByUserId(int userId)
        {
            return this.Context.Trials.Include(t => t.Voucher).Where(t => t.UserId == userId).ToList();
        }

        public List<Trial> GetByVoucherId(int userId, int voucherId)
        {
            return this.Context.Trials.Where(t => t.UserId == userId && t.VoucherId == voucherId).ToList();
        }

        public void Save(int userId, int voucherId)
        {
            Trial trial = new Trial()
            {
                UserId = userId,
                VoucherId = voucherId
            };
            this.Context.Trials.Add(trial);
        }
    }
}