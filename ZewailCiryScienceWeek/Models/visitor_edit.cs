using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class visitor_edit
    {
        [Required]
        [MaxLength(50)]
        public string fName { get; set; }
        [Required]
        [MaxLength(50)]
        public string lName { get; set; }
        [Required]
        [MaxLength(16)]
        public string national_id { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [MaxLength(20)]
        public string phone_num { get; set; }
        [Required]
        [MaxLength(50)]
        public string password { get; set; }
        public string age { get; set; }

    }
}
