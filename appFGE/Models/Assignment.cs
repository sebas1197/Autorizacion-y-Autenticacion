using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFGE.Models
{
    public class Assignment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int asg_id { get; set; }

        [Required]
        public required string asg_module { get; set; }

        [Required]
        public required int asg_rol_id { get; set; }

        [ForeignKey("asg_rol_id")]
        [Required]
        public required Role Role { get; set; }

        public bool asg_status { get; set; }

    }
}
