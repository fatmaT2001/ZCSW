using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ZewailCiryScienceWeek.Models;
using ZewailCiryScienceWeek.Pages.Visitor;

namespace ZewailCiryScienceWeek.DataClasses

{
    public class DataBase
    {
        SqlConnection con;
        public DataBase()
        {
            string Cstring = "Data Source=LAPTOP-TK7SBN2G;Initial Catalog=ZCSW;Integrated Security=True";
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
            String Q = "select commiteeName,CommitteeDescription, TeamMember_National_id,CONCAT(lName, midName,fName) as [Full name] ,TeamMember.Position  from FestivalCommitees,TeamMember,PERSON\r\nwhere TeamMember.commiteeId=FestivalCommitees.CommiteeId and PERSON.National_id=TeamMember.TeamMember_National_id";
            return ReadTable(Q);
        }


        //=============================Visitor Functions ===========================================
       
        public void adduser(Person p , visitor v)
        {
            string Q = " Insert INTO Person Values ('" + p.ssn + "', '" + p.phonenum + "', '" + p.fname + "', '" + p.midname + "', '" + p.lname + "', '" + p.email + "', '" + p.password + "', " + p.usertyep + ") ";
            excuteNonQuery(Q);


            switch (p.usertyep)
            {
                case 0:
                    string Q1 = " INSERT INTO VISITOR Visitor VALUES  ('" + p.ssn + "', " + v.age + ", '" + v.Gender + "')";
                    excuteNonQuery(Q1);
                    break;

                case 4:
                    string Q2 = " ";     //EDIT HERE
                    excuteNonQuery(Q2);
                    break;
            }

                    
      
        }
        public object Gettyep(string Email)
        {
            string Q = "SELECT userType FROM Person WHERE Email ='" + Email + "'";
            return ReadScaler(Q);
        }

         public bool CheckPassword(string Email, string password)
        {
            string Q = " Select user_password from Person  where Email= '+ Email +'";
            return (string)ReadScaler(Q) == password;
        }

        public object maxIDPerson()
        {
            int m = -1;
            string Q = " Select COUNT(*) from PERSON ";
            m = (int)ReadScaler(Q);
            return m + 1;
        }
        public object maxIDVisitor()
        {
            int m = -1;
            string Q = " Select COUNT(*) from Visitor ";
            m = (int)ReadScaler(Q);
            return m + 1;
        }

        public object maxIDResearcher()
        {
            int m = -1;
            string Q = " Select COUNT(*) from Researcher ";
            m = (int)ReadScaler(Q);
            return m + 1;
        }
        /// <summary> /// ////////////////////////////////////////////////////////////////////////////////////////

        
       

       
      

    }
}
