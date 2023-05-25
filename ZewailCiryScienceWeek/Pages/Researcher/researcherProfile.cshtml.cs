using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;
using System.Data;

namespace ZewailCiryScienceWeek.Pages.Researcher
{
    public class researcherProfileModel : PageModel
    {
        public paper p { get; set; }
        public researcher re { get; set; }
        private readonly DataBase db;
        public researcherProfileModel(DataBase db)
        {
            this.db = db;
        }

        public void OnGet(string id)
        {
            re = db.ReadResearcher(id);
            p = db.ReadPaperInfo(id);
        }
    }
}
