using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class VoucherType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Discount { get; set; }
    }
}
