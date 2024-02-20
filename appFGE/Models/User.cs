using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace appFGE.Models
{
    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int usr_id { get; set; }
        
        [Required]
        public required string usr_fullname { get; set; }

        [Required]
        public required int usr_employee_code { get; set; }

        [Required]
        public required string usr_position { get; set; }

        [Required]
        public required string usr_username { get; set; }

        [Required]
        public required string usr_password { get; set; }
      
        public string? usr_salt { get; set; }
         
        [Required]
        public DateTime usr_registration_date { get; set; }

        [Required] 
        public required int usr_rol_id { get; set; }

        [ForeignKey("usr_rol_id")]
        public Role? Role { get; set; }
        
        public bool? usr_status { get; set; } 

    }
}
