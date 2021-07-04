namespace RewardingSystem.Models
{
    public class VoucherSummary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Merchant { get; set; }
        public string Type { get; set; }
        public string Rank { get; set; }
        public string Code { get; set; }

        public int Limit { get; set; }
        public bool Purchased { get; set; }
        public int Trials { get; set; }

        public static VoucherSummary FromVoucher(Voucher rankVoucher, string code, bool hasPurchased, int trialsCount)
        {
            VoucherSummary summary = new VoucherSummary()
            {
                Id = rankVoucher.Id,
                Title = rankVoucher.Title,
                Description = rankVoucher.Description,
                Rank = rankVoucher.VoucherRank.Name,
                Type = rankVoucher.VoucherType.Name,
                Limit = rankVoucher.Limit,
                Merchant = rankVoucher.Merchant.Name,
                Purchased = hasPurchased,
                Code = code,
                Trials = trialsCount
            };
            return summary;
        }
    }
}