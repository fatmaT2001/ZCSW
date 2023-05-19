using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class visitor
    {
       
        [Required]
        [Range(10, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public int age { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public int ssn { get; set; }




        public visitor()
        {

        }








    }
}
