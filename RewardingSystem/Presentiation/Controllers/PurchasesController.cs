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
    public class PurchasesController : BasicController
    {
        public PurchasesController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            User loggedInUser = this.HttpContext.Items[Globals.CONTEXT_ITEM_USER] as User;
            List<Purchase> purchases = UnitOfWork.Purchases.GetByUserId(loggedInUser.Id);
            var results = purchases.Select(p => new
            {
                Title = p.Voucher.Title,
                Description = p.Voucher.Description,
                Code = p.Voucher.Code
            });
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

            //Get Points
            List<Transaction> transactions = UnitOfWork.Transactions.Get(userId);
            int points = transactions.Sum(t=>t.Amount);
            if (points < voucher.VoucherRank.Points)
            {
                string message = "You don't have enough points";
                throw new InsufficientPointsException(message);
            }

            //Purchase the voucher
            UnitOfWork.Purchases.Save(userId, voucherId);
            UnitOfWork.Save();
            return new EmptyResult();
        }
    }
}
