using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlTypes;
using System.Runtime.Versioning;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class userprofileModel : PageModel
    {

        private readonly DataBase db;

        [BindProperty]
        public Person p1 { get; set; }

        [BindProperty]
        public visitor v1 { get; set; }
        [BindProperty]
        public string msg { get; set; }
        public string fname { get; set; }
		public string midname { get; set; }
		public string lname { get; set; }
		public string ssn { get; set; }
		public string phonenum { get; set; }
		public string email { get; set; }

		public void OnGet()
        {
            p1 = new Person();
            p1.fname = HttpContext.Session.GetString("firstname");
			p1.midname = HttpContext.Session.GetString("middlename");
			p1.lname = HttpContext.Session.GetString("lastname");
			p1.phonenum = HttpContext.Session.GetString("phonenum");
			p1.ssn = HttpContext.Session.GetString("ssn");
			p1.email = HttpContext.Session.GetString("email");



		}

	}
}
