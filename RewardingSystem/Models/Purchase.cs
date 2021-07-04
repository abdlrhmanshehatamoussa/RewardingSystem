using System;
using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }


        [Required]
        public int VoucherId { get; set; }
        public virtual Voucher Voucher { get; set; }


        [Required]
        public DateTime Timestmap { get; set; } = DateTime.Now;
    }
}
