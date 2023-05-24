using ZewailCiryScienceWeek.Pages;
using System.ComponentModel.DataAnnotations;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Models
{
	public class Ticket
	{
		[Required]
		public  string fname { get; set; }

        [Required]
		[EmailAddress]
        public string Email { get; set; }

       // [Required]
        public int ticketid { get; set; }

       [Required]
        public string tickettype { get; set; }

        [Required]
        public string day { get; set; }

        [Required]
        public string paymentmethod { get; set; }
        public string promocode { get; set; }


    }
}
