using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class VouchersService : CRUDService
    {
        public VouchersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<Voucher> GetForUser(int userId)
        {
            List<Voucher> results = new List<Voucher>();
            //1-Get user points
            List<Transaction> transactions = UnitOfWork.Transactions.Get(userId);
            int points = transactions.Sum(t => t.Amount);

            //2-Get all the ranks below that number of points
            List<VoucherRank> ranks = UnitOfWork.VoucherRanks.GetAll();
            ranks = ranks.Where(r => r.Points <= points).ToList();

            //3-Fill vouchers of each rank
            foreach (var rank in ranks)
            {
                List<Voucher> rankVouchers = UnitOfWork.Vouchers.GetByRank(rank.Id);
                results.AddRange(rankVouchers);
            }
            return results;
        }
    }
}
