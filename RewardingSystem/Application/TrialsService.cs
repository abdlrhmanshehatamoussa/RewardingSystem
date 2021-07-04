using System;
using RewardingSystem.Exceptions;
using RewardingSystem.Models;

namespace RewardingSystem.Application
{
    public class TrialsService : CRUDService
    {
        public TrialsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void UseVoucher(int userId, int voucherId)
        {
            //Get Voucher
            Voucher voucher = UnitOfWork.Vouchers.GetById(voucherId);
            if (voucher == null)
            {
                throw new Exception("Invalid Voucher Id");
            }

            //Get purchases
            bool hasPurchased = UnitOfWork.Purchases.HasPurchased(userId, voucherId);
            if (hasPurchased == false)
            {
                string message = "Please purchase the voucher first to be able to apply it";
                throw new VoucherForbiddenException(message);
            }

            //Get Trials
            int trialsCount = UnitOfWork.Trials.GetByVoucherId(userId, voucherId).Count;

            //Check the limits
            if (trialsCount >= voucher.Limit)
            {
                throw new VoucherUsageLimitException("Number of trials were exceeded");
            }

            //Save
            UnitOfWork.Trials.Save(userId, voucherId);
            UnitOfWork.Save();
        }
    }
}
