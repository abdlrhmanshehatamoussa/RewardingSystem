using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RewardingSystem.Application
{
    public class CRUDService
    {
        protected IUnitOfWork UnitOfWork { get; set; }

        public CRUDService(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
    }
}
