using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Reflection;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.Anaylitic
{

    public class AnalysisModel : PageModel
    {
        private readonly DataBase DB;
        public DataTable dataTable { get; set; }
        // for the first chart 
        public List<int> Chart1Valuesx { get; set; }
        public List<string> Chart1Valuesy { get; set; }
        // for the second chart 
        public List<int> Chart2Valuesx { get; set; }
        public List<string> Chart2Valuesy { get; set; }
        // for the third chart 
        public List<int> Chart3Valuesx { get; set; }
        public List<int> Chart3Valuesy { get; set; }
        // for the forth chart 
        public List<int> Chart4Valuesx { get; set; }
        public List<string> Chart4Valuesy { get; set; }
        // for the fifth chart 
        public List<int> Chart5Valuesx { get; set; }
        public List<string> Chart5Valuesy { get; set; }
        // for the sixth chart 
        public List<int> Chart6Valuesx { get; set; }
        public List<int> Chart6Valuesy { get; set; }
        // for the sivinth chart 
        public List<int> Chart7Valuesx { get; set; }
        public List<string> Chart7Valuesy { get; set; }
        public AnalysisModel(DataBase db)
        {
            DB = db;
           Chart1Valuesx = new List<int>();
           Chart1Valuesy = new List<string>();
            //===================================
            Chart2Valuesx = new List<int>();
            Chart2Valuesy = new List<string>();
            //===================================
            Chart3Valuesx = new List<int>();
            Chart3Valuesy = new List<int>();
            //===================================
            Chart4Valuesx = new List<int>();
            Chart4Valuesy = new List<string>();
            //===================================
            Chart5Valuesx = new List<int>();
            Chart5Valuesy = new List<string>();
            //===================================
            Chart6Valuesx = new List<int>();
            Chart6Valuesy = new List<int>();
            //===================================
            Chart7Valuesx = new List<int>();
            Chart7Valuesy = new List<string>();
            //===================================

        }
        //==============================on get functions ======================
        public void chart1OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart1();   
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart1Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart1Valuesy.Add((string)dataTable.Rows[i][1]);
            }


        }
        public void chart2OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart2();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart2Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart2Valuesy.Add((string)dataTable.Rows[i][1]);
            }
        }
        public void chart3OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart3();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart3Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart3Valuesy.Add((int)dataTable.Rows[i][1]);
            }

        }
        public void chart4OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart4();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart4Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart4Valuesy.Add((string)dataTable.Rows[i][1]);
            }

        }
        public void chart5OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart5();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart5Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart5Valuesy.Add((string)dataTable.Rows[i][1]);
            }

        }
        public void chart6OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart6();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart6Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart6Valuesy.Add((int)dataTable.Rows[i][1]);
            }

        }

        public void chart7OnGet()
        {
            dataTable = (DataTable)DB.ongetFunctionChart3();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart3Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart3Valuesy.Add((int)dataTable.Rows[i][1]);
            }

        }

        //======================================================================
        //==============================on get functions ======================
        public void Chart1Onpost(int room,int day)
        {
            chart2OnGet();
            chart3OnGet();
            chart4OnGet();
            chart5OnGet();
            chart6OnGet();
            dataTable = (DataTable)DB.onpostFunctionChart1(room, day);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart1Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart1Valuesy.Add((string)dataTable.Rows[i][1]);
            }
            
        }
        public void Chart2Onpost(int room, int day)
        {
            chart1OnGet();
            chart3OnGet();
            chart4OnGet();
            chart5OnGet();
            chart6OnGet();
            dataTable = (DataTable)DB.onpostFunctionChart2(room, day);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart2Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart2Valuesy.Add((string)dataTable.Rows[i][1]);
            }
        }
        public void Chart3Onpost(int room)
        {
            chart1OnGet();
            chart2OnGet();
            chart4OnGet();
            chart5OnGet();
            chart6OnGet();
            dataTable = (DataTable)DB.onpostFunctionChart3(room);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart3Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart3Valuesy.Add((int)dataTable.Rows[i][1]);
            }
        }
        public void Chart4Onpost(int room,int day)
        {
            chart1OnGet();
            chart2OnGet();
            chart3OnGet();
            chart5OnGet();
            chart6OnGet();
            dataTable = (DataTable)DB.onpostFunctionChart4(room,day);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart4Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart4Valuesy.Add((string)dataTable.Rows[i][1]);
            }
        }
        public void Chart6Onpost(int room)
        {
            chart1OnGet();
            chart2OnGet();
            chart3OnGet();
            chart5OnGet();
            chart4OnGet();
            dataTable = (DataTable)DB.onpostFunctionChart6(room);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                Chart6Valuesx.Add((int)dataTable.Rows[i][0]);
                Chart6Valuesy.Add((int)dataTable.Rows[i][1]);
            }
        }

        public void OnGet()
        {
            chart1OnGet();
            chart2OnGet();
            chart3OnGet();
            chart4OnGet();
            chart5OnGet();
            chart6OnGet();

        }
        public void OnPostCHART1(int room=0,int day = 0)
        {
            if (room==0 && day == 0)
            {
                chart1OnGet();
            }
            Chart1Onpost(room,day);
        }
        public void OnPostCHART2(int room = 0, int day = 0)
        {
            if (room == 0 && day == 0)
            {
                chart2OnGet();
            }
            Chart2Onpost(room, day);
        }
        public void OnPostCHART3(int room = 0)
        {
            if (room == 0)
            {
                chart3OnGet();
            }
            Chart3Onpost(room);
        }
        public void OnPostCHART4(int room = 0, int day = 0)
        {
            if (room == 0 && day == 0)
            {
                chart4OnGet();
            }
            Chart4Onpost(room, day);
        }
        public void OnPostCHART6(int room = 0)
        {
            Chart6Onpost(room);
        }
    }
}
