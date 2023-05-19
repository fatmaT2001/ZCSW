using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class Person
    {
        [Required]
        public string fname { get; set; }
        [Required]
        public string   midname { get; set; }
        [Required]
        public string lname { get; set; }
        [Required]
        public int ssn { get; set; }
        [Required]
        public int usertyep { get; set; }

        [Required]

        public int phonenum { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [Compare(nameof(password))]
        public string repassword { get; set; }
    }
}
