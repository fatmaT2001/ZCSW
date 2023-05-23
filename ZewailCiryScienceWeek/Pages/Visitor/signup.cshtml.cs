using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ZewailCiryScienceWeek.DataClasses;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly DataBase db;

        [BindProperty]
        public Person p1 { get; set; }

        [BindProperty]
        public visitor v1 { get; set; }
        [BindProperty]
        public string msg { get; set; }
        public IndexModel(DataBase db) { this.db = db; }
        public void OnGet()
        {
            
        }
    //    public IActionResult OnPost()
    //    {
    //        if ((ModelState.IsValid)&&(p1.type == "Visitor"))
    //        {

    //            Flags.Signed = 1;
    //            Flags.Type = "Visitor";
    ////            HttpContext.Session.SetString("firstname", p1.fname);
				////HttpContext.Session.SetString("middlename", p1.midname);
				////HttpContext.Session.SetString("lastname", p1.lname);
				////HttpContext.Session.SetString("ssn", p1.ssn);
				////HttpContext.Session.SetString("Email", p1.email);
				////HttpContext.Session.SetString("phonenumber", p1.repassword);

				//db.adduser(p1 , v1);
    //            return RedirectToPage("/Visitor/userprofile");
    //        }else if ((ModelState.IsValid) && (p1.type == "Researcher"))
    //        {
    //            Flags.Signed = 1;
    //            Flags.Type = "Researcher";
    //            db.adduser(p1, v1);
    //            return RedirectToPage("researcherProfile");

    //        }
    //        else { msg = "Please Enter Valied Data "; return Page(); }


    //    }
        public static string fname { get; set; }
        
        public static string midname { get; set; }
       
        public static string lname { get; set; }
        
        public static string type { get; set; }
        
        public static string howdidyouknowus { get; set; }
       
        public static string ssn { get; set; }
        
        public static int usertype { get; set; }
        public static string phonenum { get; set; }

        public static string email { get; set; }
        public static string password { get; set; }
        
        public static string repassword { get; set; }

        public IActionResult OnPostSign()
        {
            HttpContext.Session.SetString("ssn", p1.ssn);
            HttpContext.Session.SetString("phonenumber", p1.phonenum);
            HttpContext.Session.SetString("firstname", p1.fname);
            HttpContext.Session.SetString("middlename", p1.midname);
            HttpContext.Session.SetString("lastname", p1.lname);
            HttpContext.Session.SetString("Email", p1.email);
            HttpContext.Session.SetString("password",  p1.password);
            HttpContext.Session.SetString("usertype", p1.usertype.ToString());

       
          
            if(password == repassword)
            {
                db.adduser11(p1.ssn, p1.phonenum, p1.fname, p1.midname, p1.lname, p1.email, p1.password, p1.usertype);
                return RedirectToPage("userprofile");
            }
            else
            {
                return Page();
            }


        }
    }
}
