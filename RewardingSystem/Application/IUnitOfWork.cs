namespace RewardingSystem.Application
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; set; }
        IAdminsRepository Admins { get; set; }
        IUserTokensRepository UserTokens { get; set; }
        IAdminTokensRepository AdminsTokens { get; set; }
        ITransactionsRepository Transactions { get; set; }
        
        void Save();
    }
}