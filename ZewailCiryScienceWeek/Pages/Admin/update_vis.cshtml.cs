using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;
namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class update_visModel : PageModel
    {
        [BindProperty]
        public visitor_edit vis { get; set; }
        private readonly DataBase db;
        public update_visModel(DataBase db)
        {
            this.db = db;
        }

        public void OnGet(string id)
        {

        }
        public IActionResult OnPostEdit()
        {
            
            db.UpdateVisitorInfo(vis);
            return RedirectToPage("/Admin/visitor");
        }
    }
}
