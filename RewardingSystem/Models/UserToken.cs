using System.ComponentModel.DataAnnotations;

namespace RewardingSystem.Models
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Token { get; set; }
        
        
        [Required]
        public int UserId { get; set; }
        public virtual User User {get;set;}
    }
}
