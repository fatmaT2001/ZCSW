using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class paper
    {
        public string national_id { get; set; }
        [Required]
        public string paper_name { get; set; }
        [Required]
        public int numberOfPages { get; set; }
        [Required]
        public string field { get; set; }
        public int conferenceDay { get; set; }
        [Required]
        public string SupervisorName { get; set; }
        [Required]
        public string SupervisorID { get; set; }
    }
}
