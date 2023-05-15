using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using ZewailCiryScienceWeek.DataClasses;

namespace ZewailCiryScienceWeek.Pages.MainPages
{
    public class TeamModel : PageModel
    {
        public DataBase DataBaseHolder { get; set; }
        DataTable DataTable { get; set; }
        public List<FestivalCommitteeClass> festivalCommitteeClasses { get; set; }
        public TeamModel(DataBase dataBase)
        {
            DataBaseHolder = dataBase;
            festivalCommitteeClasses = new List<FestivalCommitteeClass>();
        }
        public void commitesinfo()
        {
            DataTable = (DataTable)DataBaseHolder.CommitteesInformation();
            for (int i = 0; i < DataTable.Rows.Count; i++)
            {
                FestivalCommitteeClass temp = new FestivalCommitteeClass();
                temp.CommitteeId = (int)DataTable.Rows[i][0];
                temp.CommitteeName = (string)DataTable.Rows[i][1];
                temp.CommitteeDescription = (string)DataTable.Rows[i][2];
                DataTable datamembers = (DataTable)DataBaseHolder.committeesMembers((int)DataTable.Rows[i][0]);
                for (int m = 0; m < datamembers.Rows.Count; m++)
                {
                    TeamClass member=new TeamClass();
                    member.TeamMemberNationalId = (string)datamembers.Rows[m][0];
                    member.FirstName = (string)datamembers.Rows[m][1];
                    member.MiddleName = (string)datamembers.Rows[m][2];
                    member.LastName = (string)datamembers.Rows[m][3];
                    member.Position = (string)datamembers.Rows[m][4];
                    DataTable temp3 = (DataTable)DataBaseHolder.TeamHeadsLinks((string)DataTable.Rows[i][2]);
                    for (int j = 0; j < temp3.Rows.Count; j++)
                    {
                        member.SocialMediaLinks.Add((string)temp3.Rows[j][0]);
                    }
                    temp.Members.Add(member);

                }

                festivalCommitteeClasses.Add(temp);
            }

        }
        public void OnGet()
        {
            commitesinfo();
        }
    }
}
