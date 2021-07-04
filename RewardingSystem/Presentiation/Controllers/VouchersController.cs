using Microsoft.AspNetCore.Mvc;
using RewardingSystem.Application;
using RewardingSystem.Exceptions;
using RewardingSystem.Filters;
using RewardingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RewardingSystem.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]

    [ServiceFilter(typeof(LoggedUserFilter))]
    public class VouchersController : BasicController
    {
        public VouchersController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<dynamic> results = new List<dynamic>();
            //1-Get user points
            List<Transaction> transactions = UnitOfWork.Transactions.Get(LoggedUser.Id);
            int points = transactions.Sum(t => t.Amount);

            //2-Get all the ranks below that number of points
            List<VoucherRank> ranks = UnitOfWork.VoucherRanks.GetAll();
            ranks = ranks.Where(r => r.Points <= points).ToList();

            //3-Fill vouchers of each rank
            foreach (var rank in ranks)
            {
                List<Voucher> rankVouchers = UnitOfWork.Vouchers.GetByRank(rank.Id);
                var subResults = rankVouchers.Select(v => new
                {
                    Id = v.Id,
                    Title = v.Title,
                    Description = v.Description,
                    Rank = rank.Name,
                    Type = v.VoucherType.Name,
                    Limit = v.Limit,
                    Merchant = v.Merchant.Name
                }).ToList();
                results.AddRange(subResults);
            }

            return new JsonResult(results);
        }
    }
}
