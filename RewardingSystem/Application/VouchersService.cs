using System;
using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class VouchersService : CRUDService
    {
        public VouchersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<VoucherSummary> GetForUser(int userId)
        {
            List<VoucherSummary> results = new List<VoucherSummary>();
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
                foreach (var rankVoucher in rankVouchers)
                {
                    bool hasPurchased = UnitOfWork.Purchases.HasPurchased(userId, rankVoucher.Id);
                    List<Trial> trials = UnitOfWork.Trials.GetByVoucherId(userId, rankVoucher.Id);
                    string code = rankVoucher.Code;
                    if (hasPurchased == false)
                    {
                        code = null;
                    }
                    VoucherSummary summary = VoucherSummary.FromVoucher(rankVoucher, code,hasPurchased, trials.Count);
                    results.Add(summary);
                }
            }
            return results;
        }
    }
}


