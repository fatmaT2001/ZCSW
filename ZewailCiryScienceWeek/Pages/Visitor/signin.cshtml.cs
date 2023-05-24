using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
   
    public class signinModel : PageModel
    {
        private readonly DataBase db;

        [BindProperty]
        public Person p1 { get; set; }

        [BindProperty]
        public visitor v1 { get; set; }
        [BindProperty]
        public string msg { get; set; }

        public signinModel( DataBase dp)

        {
            this.db = dp;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost() {


            if (string.IsNullOrEmpty(p1.email) || string.IsNullOrEmpty(p1.password))
            {

                msg = "Please enter both email and password.";
                return Page();
            }
            if  (db.CheckPassword(p1.email, p1.password))
            {
                switch ((int)db.Gettyep(p1.email))
                {
                    case 0:
                        Flags.Signed = 1;
                        Flags.Type = "Visitor";
                        return RedirectToPage("userprofile");
                    case 1:
                        Flags.Signed = 1;
                        Flags.Type = "Visitor";
                        return RedirectToPage("/userprofile");
                    case 2:
                        Flags.Signed = 1;
                        Flags.Type = "Registrar";
                        return RedirectToPage("/registrar");
                    case 3:
                        Flags.Signed = 1;
                        Flags.Type = "Analyst";
                        return RedirectToPage("/Index");
                    case 4:
                        Flags.Signed = 1;
                        Flags.Type = "Researcher";
                        return RedirectToPage("/Researcher/researcherProfile");
                    default:
                        Flags.Signed = 1;
                        Flags.Type = "Visitor";
                        return RedirectToPage("/userprofile");
                }
            } else { msg = "Incorrect email or password."; return Page(); }
       
        }
    }
}
