using System.Collections.Generic;
using RewardingSystem.Application;
using RewardingSystem.Models;

namespace RewardingSystem.Persistence
{
    internal class TrialsRepository : Repository, ITrialsRepository
    {
        public TrialsRepository(DatabaseContext context) : base(context)
        {
        }

        public List<Trial> GetByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public void Save(int userId, int voucherId)
        {
            throw new System.NotImplementedException();
        }
    }
}