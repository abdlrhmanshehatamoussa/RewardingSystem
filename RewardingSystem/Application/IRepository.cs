using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Models;
namespace RewardingSystem.Application
{

    public interface ITransactionsRepository
    {
        List<Transaction> Get(int userId);
        void Add(Transaction transaction);
    }




    public interface IAdminTokensRepository
    {
        string Add(int userId);
    }
    public interface IAdminsRepository
    {
        Admin GetByToken(string token);
        Admin GetByUserName(string username);
    }




    public interface IUserTokensRepository
    {
        string Add(int userId);
    }
    public interface IUsersRepository
    {
        User GetByToken(string token);
        User GetByEmail(string email);
    }


    public interface IVouchersRepository
    {
        List<Voucher> GetByRank(int rankId);

        List<Voucher> GetByType(int typeId);
    }

    public interface IVoucherRanksRepository
    {
        List<VoucherRank> GetAll();
    }

    public interface IVoucherTypesRepository
    {
        List<VoucherType> GetAll();
    }

    public interface ITrialsRepository
    {
        void Save(int userId, int voucherId);

        List<Trial> GetByUserId(int userId);
    }

    public interface IPurchasesRepository
    {
        void Save(int userId, int voucherId);
     
        List<Purchase> GetByUserId(int userId);
    }
}