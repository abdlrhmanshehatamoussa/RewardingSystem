using RewardingSystem.Application;

namespace RewardingSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public static UnitOfWork Instance = new UnitOfWork();

        public IUsersRepository Users { get; set; }
        public IAdminsRepository Admins { get; set; }
        public IUserTokensRepository UserTokens { get; set; }
        public IAdminTokensRepository AdminsTokens { get; set; }
        public ITransactionsRepository Transactions { get; set; }

        private UnitOfWork()
        {

        }
        public static void Initialize(DatabaseContext context)
        {
            UnitOfWork.Instance.Admins = new AdminsRepository(context);
            UnitOfWork.Instance.Users = new UsersRepository(context);
            UnitOfWork.Instance.UserTokens = new UserTokensRepository(context);
            UnitOfWork.Instance.Transactions = new TransactionsRepository(context);
            UnitOfWork.Instance.AdminsTokens = new AdminTokensRepository(context);
        }

        public void Save()
        {

        }
    }
}