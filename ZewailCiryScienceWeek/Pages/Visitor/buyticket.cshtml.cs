using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class buyticketModel : PageModel


    {
        private readonly DataBase db;

        [BindProperty]
        public Person p1 { get; set; }
        [BindProperty]
        public Ticket ticket { get; set; }    

        [BindProperty]
        public visitor v1 { get; set; }
        [BindProperty]
        public string msg { get; set; }

        public buyticketModel(DataBase dp)

        {
            this.db = dp;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                db.InsertnewTicket(ticket);
                return RedirectToPage("ticketdesign");
            }
            else { msg = "Please Enter Valied Data "; return Page(); }
        }
    }

}

