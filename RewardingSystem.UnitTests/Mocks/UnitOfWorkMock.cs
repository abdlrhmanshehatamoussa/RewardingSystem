using RewardingSystem.Application;

namespace Tests
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        public IAdminsRepository Admins { get; set; }
        public IUserTokensRepository UserTokens { get; set; }
        public IMerchantsRepository Merchants { get; set; }
        public IAdminTokensRepository AdminsTokens { get; set; }
        public IUsersRepository Users { get; set; } = new UsersMockRepo();
        public ITransactionsRepository Transactions { get; set; } = new TransactionsMockRepo();
        public IVouchersRepository Vouchers { get; set; } = new VouchersMockRepo();
        public IVoucherRanksRepository VoucherRanks { get; set; } = new VoucherRanksMockRepo();
        public IVoucherTypesRepository VoucherTypes { get; set; } = new VoucherTypesMockRepo();
        public ITrialsRepository Trials { get; set; } = new TrialsMockRepo();
        public IPurchasesRepository Purchases { get; set; } = new PurchasesMockRepo();

        public void Save()
        {

        }
    }
}