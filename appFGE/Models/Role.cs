using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFGE.Models
{ 
    public class Role
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int rol_id { get; set; } 

        [Required] 
        public required string rol_name { get; set; }

        public bool? rol_status { get; set; }
        public List<User>? Users { get; set; }

    }
} 
