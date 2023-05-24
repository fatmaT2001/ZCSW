using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages
{
    public class registrarModel : PageModel
    {
        private readonly DataBase database;
        public int RemainingDay1Vip { get; set; }
        public int RemainingDay2Vip { get; set; }
        public int RemainingDay3Vip { get; set; }
        public int RemainingDay4Vip { get; set; }
        public int RemainingDay5Vip { get; set; }
        public int RemainingDay6Vip { get; set; }
        public int RemainingDay7Vip { get; set; }
        public int RemainingDay1reg { get; set; }
        public int RemainingDay2reg { get; set; }
        public int RemainingDay3reg { get; set; }
        public int RemainingDay4reg { get; set; }
        public int RemainingDay5reg { get; set; }
        public int RemainingDay6reg { get; set; }
        public int RemainingDay7reg { get; set; }
        public int RemainingDay1zew { get; set; }
        public int RemainingDay2zew { get; set; }
        public int RemainingDay3zew { get; set; }
        public int RemainingDay4zew { get; set; }
        public int RemainingDay5zew { get; set; }
        public int RemainingDay6zew { get; set; }
        public int RemainingDay7zew { get; set; }
        public int bookedday1vip { get; set; }

        public int bookedday2vip { get; set; }
        public int bookedday3vip { get; set; }
        public int bookedday4vip { get; set; }
        public int bookedday5vip { get; set; }
        public int bookedday6vip { get; set; }
        public int bookedday7vip { get; set; }
        public int bookedday1reg { get; set; }
        public int bookedday2reg { get; set; }
        public int bookedday3reg { get; set; }
        public int bookedday4reg { get; set; }
        public int bookedday5reg { get; set; }
        public int bookedday6reg { get; set; }
        public int bookedday7reg { get; set; }
        public int bookedday1zew { get; set; }
        public int bookedday2zew { get; set; }
        public int bookedday3zew { get; set; }
        public int bookedday4zew { get; set; }
        public int bookedday5zew { get; set; }
        public int bookedday6zew { get; set; }
        public int bookedday7zew { get; set; }
        public registrarModel()
        {
            database = new DataBase();
        }
        public void OnGet()
        {
            DataBase db = new DataBase();

            // Retrieve the remaining day 1 VIP count from the database
            RemainingDay1Vip = db.getremainticket("day1", "VIP");
            RemainingDay2Vip = db.getremainticket("day2", "VIP");
            RemainingDay3Vip = db.getremainticket("day3", "VIP");
            RemainingDay4Vip = db.getremainticket("day4", "VIP");
            RemainingDay5Vip = db.getremainticket("day5", "VIP");
            RemainingDay6Vip = db.getremainticket("day6", "VIP");
            RemainingDay7Vip = db.getremainticket("day7", "VIP");
            RemainingDay1reg = db.getremainticket("day1", "regular");
            RemainingDay2reg = db.getremainticket("day2", "regular");
            RemainingDay3reg = db.getremainticket("day3", "regular");
            RemainingDay4reg = db.getremainticket("day4", "regular");
            RemainingDay5reg = db.getremainticket("day5", "regular");
            RemainingDay6reg = db.getremainticket("day6", "regular");
            RemainingDay7reg = db.getremainticket("day7", "regular");
            RemainingDay1zew = db.getremainticket("day1", "zewilains");
            RemainingDay2zew = db.getremainticket("day2", "zewilains");
            RemainingDay3zew = db.getremainticket("day3", "zewilains");
            RemainingDay4zew = db.getremainticket("day4", "zewilains");
            RemainingDay5zew = db.getremainticket("day5", "zewilains");
            RemainingDay6zew = db.getremainticket("day6", "zewilains");
            RemainingDay7zew = db.getremainticket("day7", "zewilains");
            bookedday1vip = db.getbookedticket("day1", "VIP");
            bookedday2vip = db.getbookedticket("day2", "VIP");
            bookedday3vip = db.getbookedticket("day3", "VIP");
            bookedday4vip = db.getbookedticket("day4", "VIP");
            bookedday5vip = db.getbookedticket("day5", "VIP");
            bookedday6vip = db.getbookedticket("day6", "VIP");
            bookedday7vip = db.getbookedticket("day7", "VIP");
            bookedday1reg = db.getbookedticket("day1", "regular");
            bookedday2reg = db.getbookedticket("day2", "regular");
            bookedday3reg = db.getbookedticket("day3", "regular");
            bookedday4reg = db.getbookedticket("day4", "regular");
            bookedday5reg = db.getbookedticket("day5", "regular");
            bookedday6reg = db.getbookedticket("day6", "regular");
            bookedday7reg = db.getbookedticket("day7", "regular");
            bookedday1zew = db.getbookedticket("day1", "zewilains");
            bookedday2zew = db.getbookedticket("day2", "zewilains");
            bookedday3zew = db.getbookedticket("day3", "zewilains");
            bookedday4zew = db.getbookedticket("day4", "zewilains");
            bookedday5zew = db.getbookedticket("day5", "zewilains");
            bookedday6zew = db.getbookedticket("day6", "zewilains");
            bookedday7zew = db.getbookedticket("day7", "zewilains");






        }

        [BindProperty]
        public int ticketQuantity { get; set; }
        [BindProperty]
        public string dayAttending { get; set; }
        public IActionResult OnPostUpdate()
        {

            database.UpdateNumberOfTickets(ticketQuantity, dayAttending);
            //database.getremainticket(dayAttending, "regular");
            return Page();
        }
        [BindProperty]
        public string day { get; set; }
        [BindProperty]
        public string type { get; set; }
        public DataTable dt { get; set; }


        public IActionResult OnPostView()
        {
            HttpContext.Session.SetString("day", day);
            HttpContext.Session.SetString("type", type);


            return RedirectToPage("registrarvisitor");
           //dt =  (DataTable)database.viewvisitors(day, type);

        }
    }
}