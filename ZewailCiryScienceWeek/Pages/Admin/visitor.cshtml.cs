using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class visitorModel : PageModel
    {

        [BindProperty]
        public visitor_edit vis { get; set; }
        public DataTable dt { get; set; }

        private readonly DataBase db;
        public visitorModel(DataBase DB)
        {
            this.db = DB;
        }

        public void OnGet()
        {
            dt = (DataTable)db.DisplayVisitors();
            //vis = new visitor_edit();
            //vis =(visitor_edit) db.ReadVisitorRow( id);

        }
        public void OnPost()
        {
            HttpContext.Session.SetString("national_id", vis.national_id);
            HttpContext.Session.SetString("fName", vis.fName);
            HttpContext.Session.SetString("lName", vis.lName);
            HttpContext.Session.SetString("email", vis.email);
            HttpContext.Session.SetString("phone_num", vis.phone_num);
            HttpContext.Session.SetString("password", vis.password);
            HttpContext.Session.SetString("age", vis.age);

        }


    }
}
