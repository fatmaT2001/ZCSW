using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.Admin
{
    public class ticketsModel : PageModel
    {
        public DataTable dt { get; set; }
        private readonly DataBase db;
        public ticketsModel(DataBase DB)
        {
            this.db = DB;
        }
        public void OnGet()
        {
            dt = (DataTable)db.DisplayTickets();
        }
    }
}
