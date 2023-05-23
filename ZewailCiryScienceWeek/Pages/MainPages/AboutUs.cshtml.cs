using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.MainPages
{
    public class AboutUsModel : PageModel
    {
        public DataBase dataBase { get; set; }
        public DataTable DataTable { get; set; }
        public AboutUsModel(DataBase dataBase)
        {
            this.dataBase = dataBase;
            DataTable = new DataTable();
        }

        public void OnGet()
        {
            DataTable = (DataTable)dataBase.AboutUsRooms();
        }
        public void OnPost(string part) {
            DataTable = (DataTable)dataBase.searchingAbouTUsPage(part);
        }
    }
}
