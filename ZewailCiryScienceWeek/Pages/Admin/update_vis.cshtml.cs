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
        public visitor_edit vi { get; set; }
        private readonly DataBase db;
        public update_visModel(DataBase db)
        {
            this.db = db;
        }

        public void OnGet(string id)
        {
            vis = new visitor_edit();
            vi = db.ReadVisitorRow(id);
            //visitor_edit v = new visitor_edit();
            vis.national_id = vi.national_id;
            vis.fName = vi.fName;
            vis.lName = vi.lName;
            vis.email = vi.email;
            vis.age = vi.age;
            vis.phone_num = vi.phone_num;
        }
        public IActionResult OnPost()
        {

            //vis.fName = HttpContext.Session.GetString("fName");
            //vis.lName = HttpContext.Session.GetString("lName");
            //vis.national_id = HttpContext.Session.GetString("namtional_id");
            //vis.email = HttpContext.Session.GetString("email");
            //vis.phone_num = HttpContext.Session.GetString("phone_num");
            db.UpdateVisitorInfo(vis);
            return RedirectToPage("/Admin/visitor");
        }
    }
}


