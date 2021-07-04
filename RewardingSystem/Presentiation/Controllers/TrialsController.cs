using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Filters;
using RewardingSystem.Helpers;
using RewardingSystem.Models;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [ServiceFilter(typeof(LoggedUserFilter))]
    public class TrialsController : BasicController
    {
        public TrialsController(IUnitOfWork uow) : base(uow)
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            //Get user
            User loggedInUser = this.HttpContext.Items[Globals.CONTEXT_ITEM_USER] as User;

            //Get Trials
            List<Trial> trials = UnitOfWork.Trials.GetByUserId(loggedInUser.Id);

            //Group the trials
            var groups = trials.GroupBy(t => t.Voucher.Title);
            List<TrialsSummary> results = new List<TrialsSummary>();
            foreach (var group in groups)
            {
                results.Add(new TrialsSummary()
                {
                    VoucherTitle = group.Key,
                    Trials = group.Count()
                });
            }
            return new JsonResult(results);
        }

        [HttpPost]
        public IActionResult Post([FromBody] dynamic request)
        {
            //Get User
            User loggedInUser = this.HttpContext.Items[Globals.CONTEXT_ITEM_USER] as User;
            int userId = loggedInUser.Id;

            //Get Voucher
            int voucherId = request.VoucherId;
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
            string fakeMessage = string.Format("Discount of {0}% has been applied", voucher.VoucherType.Discount);
            return new JsonResult(new
            {
                Status = fakeMessage
            });
        }



        private class TrialsSummary
        {
            public string VoucherTitle { get; set; }
            public int Trials { get; set; }
        }
    }
}
