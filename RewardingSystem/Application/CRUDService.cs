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
