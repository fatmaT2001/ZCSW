using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class ticketdesignModel : PageModel
    {
        private readonly DataBase db;
        [BindProperty]
        public Ticket ticket { get; set; }
        public string fname { get; set; }
        public string Email { get; set; }
        public string ticketid { get; set; }
        public string tickettype { get; set; }
        public string paymentmethod { get; set; }
        public int promocode { get; set; }


        public void OnGet()
        {
            ticket = new Ticket();
            ticket.fname = HttpContext.Session.GetString("fname");
            HttpContext.Session.GetString("Email");
            HttpContext.Session.GetString("ticketid");
            HttpContext.Session.GetString("tickettype");
            HttpContext.Session.GetString("day");
            HttpContext.Session.GetString("paymentmethod");
            HttpContext.Session.GetString("promocode");
        }
    }
}
