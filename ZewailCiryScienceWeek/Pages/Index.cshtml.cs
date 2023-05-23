using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public DataBase DataBaseHolder { get; set; }
        DataTable DataTable { get; set; }
        public List<SpeakerClass> speakerClasses =new List<SpeakerClass>();
        public List<TeamClass> TeamClasses = new List<TeamClass>();
        public List<DataTable>speakerScdule {  get; set; }
        public List<DataTable>roomsScdule {  get; set; }

        public IndexModel(ILogger<IndexModel> logger, DataBase dataBase)
        {
            _logger = logger;
            DataBaseHolder = dataBase;
            speakerScdule = new List<DataTable>();
            roomsScdule = new List<DataTable>();
        }
        // ======================MainPage Team Section ===============================
        private void TeamHeads()
        {

            DataTable = (DataTable)DataBaseHolder.TeamHeads();
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {
                TeamClass temp = new TeamClass();
                DataTable socailMedaiAccount = new DataTable();
                temp.TeamMemberNationalId = (string)DataTable.Rows[i][0];
                temp.FirstName = (string)DataTable.Rows[i][1];
                temp.MiddleName = (string)DataTable.Rows[i][2];
                temp.LastName = (string)DataTable.Rows[i][3];
                temp.Position = (string)DataTable.Rows[i][5];
                temp.CommitteeName = (string)DataTable.Rows[i][6];
                //temp.TeamMemberPicture = (string)DataTable.Rows[i][2];
                socailMedaiAccount = (DataTable)DataBaseHolder.TeamHeadsLinks((string)DataTable.Rows[i][0]);
                for (int j = 0; j < socailMedaiAccount.Rows.Count; j++)
                {
                    temp.SocialMediaLinks.Add((string)socailMedaiAccount.Rows[j][0]);
                }
                temp.SocialMediaLinks.Add((string)DataTable.Rows[i][4]);
                TeamClasses.Add(temp);


            }
        }
        // ======================MainPage Team Section ===============================
        private void Speakers()
        {
            DataTable = (DataTable)DataBaseHolder.SpeakersInfo();
            for (int i=0;i<DataTable.Rows.Count;i++)
            {
                SpeakerClass speaker= new SpeakerClass();
                speaker.SpeakerNationalId = (string)DataTable.Rows[i][0];
                speaker.FirstName = (string)DataTable.Rows[i][1];
                speaker.MiddleName = (string)DataTable.Rows[i][2];
                speaker.LastName = (string)DataTable.Rows[i][3];
                speaker.Category = (string)DataTable.Rows[i][4];
                speaker.Topic = (string)DataTable.Rows[i][5];
                speaker.SpeakerExperienceInfo = (string)DataTable.Rows[i][6];
                speaker.Topicdescription = (string)DataTable.Rows[i][7];
                DataTable socailMedaiAccount = new DataTable();
                socailMedaiAccount = (DataTable)DataBaseHolder.SpeakersLinks((string)DataTable.Rows[i][0]);
                for (int j = 0; j < socailMedaiAccount.Rows.Count; j++)
                {
                    speaker.SocialMediaLinks.Add((string)socailMedaiAccount.Rows[j][0]);
                }
                speaker.SocialMediaLinks.Add((string)DataTable.Rows[i][5]);
                speakerClasses.Add(speaker);
            }
        }
        public void OnGet()
        {
            TeamHeads();
            Speakers();
            for(int i = 1; i <= 7; ++i)
            {
                DataTable temp = (DataTable)DataBaseHolder.speakersechudle(i);
                speakerScdule.Add(temp);
                temp = (DataTable)DataBaseHolder.roomsechudle(i);
                roomsScdule.Add(temp);
            }
        }
    }
}