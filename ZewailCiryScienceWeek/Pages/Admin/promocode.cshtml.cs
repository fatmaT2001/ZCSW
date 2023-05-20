using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ZewailCiryScienceWeek.Pages.Admin
using System.Data;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;
namespace projecttt.Pages
{
    public class promocodeModel : PageModel
    {
        [BindProperty]
        public promocode pc { get; set; }
        private readonly DataBase db;

        public promocodeModel(DataBase DB)
        {
            this.db = DB;
        }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            if(ModelState.IsValid)
            {
                db.InsertRowPromo(pc);
                return RedirectToPage("/Admin/Promotable");
            }
            else
            {
                return Page();
            }
        }
    }
}
