using System;
using System.Collections.Generic;
using System.Linq;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class PurchasesService : CRUDService
    {
        public PurchasesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public void PurchaseVoucher(int userId, int voucherId)
        {
            Voucher voucher = UnitOfWork.Vouchers.GetById(voucherId);
            if (voucher == null)
            {
                throw new Exception("Invalid Voucher Id");
            }

            //Get Points
            List<Transaction> transactions = UnitOfWork.Transactions.Get(userId);
            int points = transactions.Sum(t => t.Amount);
            if (points < voucher.VoucherRank.Points)
            {
                string message = "You don't have enough points";
                throw new InsufficientPointsException(message);
            }

            //Purchase the voucher
            UnitOfWork.Purchases.Save(userId, voucherId);
            UnitOfWork.Save();
        }
    }
}


