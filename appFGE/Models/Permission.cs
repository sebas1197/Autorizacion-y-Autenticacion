using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFGE.Models
{
    public class Permission
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int per_id { get; set; }

        [Required]
        public required string per_action { get; set; }

        [Required]
        public required int per_rol_id { get; set; }

        [ForeignKey("per_rol_id")]  
        public Role? Role { get; set; }
        
        public bool? per_status { get; set; }
    }
}
