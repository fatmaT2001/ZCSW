using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages
{
    public class registrarvisitorModel : PageModel
    {
        private readonly DataBase database;
        public registrarvisitorModel() { database = new DataBase();}

        public string day { get; set; }
        
        public string type { get; set; }
        public DataTable dt { get; set; }
        public void OnGet()
        {
            day = HttpContext.Session.GetString("day");
            type = HttpContext.Session.GetString("type");
            dt = (DataTable)database.viewvisitors(day, type);
            
        }

    }
    }

