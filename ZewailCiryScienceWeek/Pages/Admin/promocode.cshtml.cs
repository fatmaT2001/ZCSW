using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;
namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class promocodeModel : PageModel
    {

        private readonly DataBase db;

        [BindProperty]
        public promocode pc { get; set; }
        public promocodeModel(DataBase DB)
        {
            this.db = DB;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.InsertRowPromo(pc);
                return RedirectToPage("Admin/Promotable");
            }
            else
            {
                return Page();
            }
        }
    }
}
