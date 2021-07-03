using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public int ReferenceNumber { get; set; }
        
        
        [Required]
        public int UserId { get; set; }
        public virtual User User {get;set;}
    }
}
