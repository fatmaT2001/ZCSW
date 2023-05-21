using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class PromotableModel : PageModel
    {
        public DataTable dt { get; set; }
        private readonly DataBase db;
        public PromotableModel(DataBase DB)
        {
            this.db = DB;
        }
        public void OnGet()
        {
            dt = (DataTable)db.ReadAllTable("PromoCodes");
        }
    }
}
