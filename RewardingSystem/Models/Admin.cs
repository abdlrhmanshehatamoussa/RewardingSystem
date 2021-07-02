using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RewardingSystem.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        //Navigation Property
        [InverseProperty("Admin")]
        public List<AdminToken> AdminTokens{get;set;}
    }
}
