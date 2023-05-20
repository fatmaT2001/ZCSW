using System.ComponentModel.DataAnnotations;

namespace ZewailCiryScienceWeek.Models
{
    public class promocode
    {
        [Required]
        public string PromoName { get; set; }
        [Required]
        [Range(0, 100)]
        public int DiscountPercent { get; set; }
        [Required]
        [Range(0, 1000)]
        public int NumTicketsOffered { get; set; }
        [Required]
        [Range(0, 20)]
        public int NumOfPassing { get; set; }
        [Required]
        public string AssignedTo { get; set; }

    }
}
