using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RewardingSystem.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        
        //Navigation Property
        [InverseProperty("User")]
        public virtual List<UserToken> UserTokens{get;set;}

        //Navigation Property
        [InverseProperty("User")]
        public virtual List<Transaction> Transactions{get;set;}
    }
}
