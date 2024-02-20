using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appFGE.Models
{
    public class Session
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ses_id { get; set; }

        [Required]
        public required string ses_jwt { get; set; }

        public DateTime? ses_expiration_time { get; set; }

        [Required] 
        public required int ses_usr_id { get; set; }

        [ForeignKey("ses_usr_id")]  
        public User? User { get; set; }

        [DefaultValue(true)]
        public bool ses_status { get; set; }

        [Required]
        public required string ses_ip { get; set; }

        [Required]
        public required string ses_browser { get; set; }

        public DateTime? ses_date_time { get; set; }

    }
}