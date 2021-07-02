using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class AdminToken
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Token { get; set; }
        
        
        [Required]
        public int AdminId { get; set; }
        public virtual Admin Admin{get;set;}
    }
}
