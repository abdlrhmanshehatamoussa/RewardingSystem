using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class VoucherRank
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }
    }
}
