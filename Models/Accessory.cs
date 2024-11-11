using System.ComponentModel.DataAnnotations;

namespace manage_my_assets.Models
{
    public class Accessory : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
