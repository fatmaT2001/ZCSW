using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
namespace projecttt.Pages
{
    public class promocodeModel : PageModel
    {
        public DataTable dt { get; set; }
        public void OnGet()
        {
            // dt = ReadTable("");
        }
    }
}
