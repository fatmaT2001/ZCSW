using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ZewailCiryScienceWeek.DataClasses

{
    public class DataBase
    {
        SqlConnection con;
        public DataBase()
        {
            string Cstring = "Data Source=DESKTOP-ECB5J03;Initial Catalog=ZCSW;Integrated Security=True";
            con = new SqlConnection(Cstring);
        }

        private object ReadTable(string query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                con.Open();
                SqlCommand comand = new SqlCommand(query, con);
                dataTable.Load(comand.ExecuteReader());
                con.Close();
                return dataTable;

            }
            catch (Exception ex)
            {
                con.Close();
                return ex;
            }
        }
        private object ReadScaler(string query)
        {
            try
            {
                con.Open();
                SqlCommand comand = new SqlCommand(query, con);
                int reader = (int)comand.ExecuteScalar();
                con.Close();
                return reader;

            }
            catch (Exception ex)
            {
                con.Close();
                return ex;
            }
        }
        private void excuteNonQuery(string query)
        {
            try
            {
                con.Open();
                SqlCommand comand = new SqlCommand(query, con);
                comand.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                con.Close();
                Console.WriteLine("sql exception",ex);
            }
        }
        //==========================Main page Functions ==========================
        // =============== Start Team section =======
        public object TeamHeads()
        {
            string Q = "select National_id,lName,midName,fName,Email,Position,commiteeName from PERSON ,TeamMember ,FestivalCommitees where  PERSON.National_id=TeamMember.TeamMember_National_id and TeamMember.commiteeId=FestivalCommitees.CommiteeId and Position='Head'";
            return ReadTable(Q);
        }
        public object TeamHeadsLinks(string id )
        {
            string Q = "select SocialMedia.SocialMediaLinke from SocialMedia , TeamMember where  TeamMember.TeamMember_National_id=SocialMedia.nationalId and TeamMember.TeamMember_National_id='"+ id+"'";
            return ReadTable(Q);
        }
        // =============== End Team section =======
        // =============== Start speaker section =======
        public object SpeakersInfo()
        {
            string Q = "select * from PERSON, Speaker where Speaker.Speaker_National_id=PERSON.National_id";
            return ReadTable(Q);
        }
        public object SpeakersLinks(string id)
        {
            string Q = "select SocialMedia.SocialMediaLinke from SocialMedia , Speaker where Speaker.Speaker_National_id=SocialMedia.nationalId and Speaker.Speaker_National_id='"+ id + "'";
            return ReadTable(Q);
        }
        //========================================================================
        //==========================Team page Functions  =========================
      
        public object CommitteesInformation()
        {
            String Q = "select commiteeId,commiteeName,CommitteeDescription from FestivalCommitees";
            return ReadTable(Q);
        }
        public object committeesMembers(int id)
        {
            string Q = "select TeamMember_National_id,lName,midName ,fName ,TeamMember.Position  from FestivalCommitees,TeamMember,PERSON where TeamMember.commiteeId=FestivalCommitees.CommiteeId and PERSON.National_id=TeamMember.TeamMember_National_id and TeamMember.commiteeId=1";
            return ReadTable(Q);
        }
        //========================================================================
        public object searchingSpeakers(string part)
        {
            string Q = "select * from PERSON, Speaker where Speaker.Speaker_National_id=PERSON.National_id AND (\r\n    Speaker.category LIKE '%"+part+"%' \r\n    OR fname LIKE '%" + part+"%' \r\n    OR midName LIKE '%" + part+"%' \r\n    OR lName LIKE '%"+part+ "%' \r\n    OR Speaker.SpeakerExperianceInfo LIKE '%"+part+ "%' \r\n    OR Speaker.topicDescription LIKE '%"+part+"%'\r\n)";
            return ReadTable(Q);

        }
        //========================================================================
    }
}
