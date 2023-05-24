using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class researcher
    {

        [Required]
        [Range(10, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int age { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string ssn { get; set; }
        public string id { get; set; }
        public string knowus { get; set; }
    }
}
