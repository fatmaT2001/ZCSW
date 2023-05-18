using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
namespace projecttt.Pages
{
    public class ticketsModel : PageModel
    {
        public DataTable dt { get; set; }
        public void OnGet()
        {
            // dt = ReadTable("");
        }
    }
}
