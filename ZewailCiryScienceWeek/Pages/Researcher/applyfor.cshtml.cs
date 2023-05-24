using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO.Pipelines;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Researcher
{
    public class applyforModel : PageModel
    {
        private readonly DataBase db;
        [BindProperty]
        public paper p { get; set; }
        public applyforModel(DataBase db)
        {
            this.db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            db.InsertPaper(p);
            return RedirectToPage("/Researcher/researcherProfile");

        }
    }
}


