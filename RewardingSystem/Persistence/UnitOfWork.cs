using RewardingSystem.Application;

namespace RewardingSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUsersRepository Users { get; set; }
        public IAdminsRepository Admins { get; set; }
        public IUserTokensRepository UserTokens { get; set; }
        public IAdminTokensRepository AdminsTokens { get; set; }
        public ITransactionsRepository Transactions { get; set; }
        private DatabaseContext Context { get; set; }
        public IVouchersRepository Vouchers { get; set; }
        public IVoucherRanksRepository VoucherRanks { get; set; }
        public IVoucherTypesRepository VoucherTypes { get; set; }

        public UnitOfWork(DatabaseContext context)
        {
            this.Context = context;
            this.Admins = new AdminsRepository(context);
            this.Users = new UsersRepository(context);
            this.UserTokens = new UserTokensRepository(context);
            this.Transactions = new TransactionsRepository(context);
            this.AdminsTokens = new AdminTokensRepository(context);
            this.Vouchers = new VouchersRepository(context);
            this.VoucherTypes = new VoucherTypesRepository(context);
            this.VoucherRanks = new VoucherRanksRepository(context);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}