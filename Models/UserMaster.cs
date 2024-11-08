using System.ComponentModel.DataAnnotations;

namespace manage_my_assets.Models
{
    public class UserMaster
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
