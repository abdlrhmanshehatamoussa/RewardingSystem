using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Limit { get; set; }

        [Required]
        public string Code { get; set; }


        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }


        public int VoucherRankId { get; set; }
        public VoucherRank VoucherRank { get; set; }

        
        public int VoucherTypeId { get; set; }
        public VoucherType VoucherType { get; set; }

    }
}
