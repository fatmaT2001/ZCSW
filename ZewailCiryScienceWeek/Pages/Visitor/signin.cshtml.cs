using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class signinModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPost() {
            // if the user has the viladity to sign in please add this extry line 
            Flags.Signed = 1;
            // and change its type 
            Flags.Type = "Analysts";
            return RedirectToPage("/Index");
            // if the user has not the viladity to sign in please add this extry line
            //Flags.Signed = 0;
            //Flags.Type = "";
        }
    }
}
