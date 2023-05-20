using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class IndexModel : PageModel
    {
       
        private readonly DataBase db;

        [BindProperty]
        public Person p1 { get; set; }

        [BindProperty]
        public visitor v1 { get; set; }
        [BindProperty]
        public string msg { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if ((ModelState.IsValid)&&(p1.type == "Visitor"))
            {
                Flags.Signed = 1;
                Flags.Type = "Visitor";
                db.adduser(p1, v1);
                return RedirectToPage("userprofile");
            }else if ((ModelState.IsValid) && (p1.type == "Researcher"))
            {
                Flags.Signed = 1;
                Flags.Type = "Researcher";
                db.adduser(p1, v1);
                return RedirectToPage("researcherProfile");

            }
            else { msg = "Please Enter Valied Data "; return Page(); }


        }
    }
}
