using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;
namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class delete_visModel : PageModel
    {
        [BindProperty]
        public visitor_edit vis { get; set; }
        private readonly DataBase db;
        public delete_visModel(DataBase DB)
        {
            this.db = DB;
        }
        public void OnGet(string id)
        {
            vis = db.ReadVisitorRow(id);
        }
        public IActionResult OnPost()
        {
            db.RemoveVisitor(vis.national_id);
            return RedirectToPage("/Admin/visitor");
        }
    }
}
