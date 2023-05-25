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
        public string email { get; set; }
        public string phone { get; set; }
        public string job { get; set; }

        public string name { get; set; }
        public string adress { get; set; }
        public string id { get; set; }
        public string knowus { get; set; }
    }
}
