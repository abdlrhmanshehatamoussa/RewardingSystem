using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Filters;
using RewardingSystem.Helpers;
using RewardingSystem.Models;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(summary: "Lists all the purchased vouchers for the logged in user (User Token Required)")]
        public IActionResult Get()
        {
            List<Purchase> purchases = UnitOfWork.Purchases.GetByUserId(LoggedUser.Id);
            var results = purchases.Select(p => new
            {
                Title = p.Voucher.Title,
                Description = p.Voucher.Description,
                Code = p.Voucher.Code
            });
            return new JsonResult(results);
        }

        [HttpPost]
        [SwaggerOperation(summary: "Purchases a voucher [VoucherId] for the logged in user (User Token Required)")]
        public IActionResult Post([FromBody] dynamic request)
        {
            //Get Voucher
            int voucherId = request.VoucherId;
            Voucher voucher = UnitOfWork.Vouchers.GetById(voucherId);
            if (voucher == null)
            {
                throw new Exception("Invalid Voucher Id");
            }

            //Get Points
            List<Transaction> transactions = UnitOfWork.Transactions.Get(LoggedUser.Id);
            int points = transactions.Sum(t => t.Amount);
            if (points < voucher.VoucherRank.Points)
            {
                string message = "You don't have enough points";
                throw new InsufficientPointsException(message);
            }

            //Purchase the voucher
            UnitOfWork.Purchases.Save(LoggedUser.Id, voucherId);
            UnitOfWork.Save();
            return new EmptyResult();
        }
    }
}
