using System.Collections.Generic;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class MerchantsService : CRUDService
    {
        public MerchantsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<Merchant> GetAll()
        {
            return this.UnitOfWork.Merchants.GetAll();
        }
    }
}
