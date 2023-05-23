using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.MainPages
{
    public class SpeakersModel : PageModel
    {
        public DataBase DataBaseHolder { get; set; }
        DataTable DataTable { get; set; }
        public List<SpeakerClass> speakerClasses = new List<SpeakerClass>();
        public SpeakersModel( DataBase dataBase)
        {
            DataBaseHolder= dataBase;
        }
        private void Speakers(DataTable dataTable)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                SpeakerClass speaker = new SpeakerClass();
                speaker.SpeakerNationalId = (string)dataTable.Rows[i][0];
                speaker.FirstName = (string)dataTable.Rows[i][1];
                speaker.MiddleName = (string)dataTable.Rows[i][2];
                speaker.LastName = (string)dataTable.Rows[i][3];
                speaker.Category = (string)dataTable.Rows[i][4];
                speaker.Topic = (string)dataTable.Rows[i][5];
                speaker.SpeakerExperienceInfo = (string)dataTable.Rows[i][6];
                speaker.Topicdescription = (string)dataTable.Rows[i][7];
                DataTable socailMedaiAccount = new DataTable();
                socailMedaiAccount = (DataTable)DataBaseHolder.SpeakersLinks((string)dataTable.Rows[i][0]);
                for (int j = 0; j < socailMedaiAccount.Rows.Count; j++)
                {
                    speaker.SocialMediaLinks.Add((string)socailMedaiAccount.Rows[j][0]);
                }
                speaker.SocialMediaLinks.Add((string)dataTable.Rows[i][5]);
                speakerClasses.Add(speaker);
            }
        }
        public void OnGet()
        {
            DataTable = (DataTable)DataBaseHolder.SpeakersInfo();
            Speakers(DataTable);
        }
        public void OnPost(string part)
        {
            DataTable=(DataTable)DataBaseHolder.searchingSpeakers(part);
            Speakers(DataTable);
        }

    }
}
