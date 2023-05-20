using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ZewailCiryScienceWeek.Models;

namespace ZewailCiryScienceWeek.DataClasses

{
    public class DataBase
    {
        SqlConnection con;
        public DataBase()
        {
            string Cstring = "Data Source=SHROUK;Initial Catalog=ZCSF_DB;Integrated Security=True";
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
                Console.WriteLine("sql exception", ex);
            }
        }
        //==========================Main page Functions ==========================
        // =============== Start Team section =======
        public object TeamHeads()
        {
            string Q = "select National_id,lName,midName,fName,Email,Position,commiteeName from PERSON ,TeamMember ,FestivalCommitees where  PERSON.National_id=TeamMember.TeamMember_National_id and TeamMember.commiteeId=FestivalCommitees.CommiteeId and Position='Head'";
            return ReadTable(Q);
        }
        public object TeamHeadsLinks(string id)
        {
            string Q = "select SocialMedia.SocialMediaLinke from SocialMedia , TeamMember where  TeamMember.TeamMember_National_id=SocialMedia.nationalId and TeamMember.TeamMember_National_id='" + id + "'";
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
            string Q = "select SocialMedia.SocialMediaLinke from SocialMedia , Speaker where Speaker.Speaker_National_id=SocialMedia.nationalId and Speaker.Speaker_National_id='" + id + "'";
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
            string Q = "select TeamMember_National_id,lName,midName ,fName ,TeamMember.Position  from FestivalCommitees,TeamMember,PERSON where TeamMember.commiteeId=FestivalCommitees.CommiteeId and PERSON.National_id=TeamMember.TeamMember_National_id and TeamMember.commiteeId=" + id;
            return ReadTable(Q);
        }
        //========================================================================
        //============================Searching Part==============================
        public object searchingSpeakers(string part)
        {
            string Q = "select * from PERSON, Speaker where Speaker.Speaker_National_id=PERSON.National_id AND (\r\n    Speaker.category LIKE '%" + part + "%' \r\n    OR fname LIKE '%" + part + "%' \r\n    OR midName LIKE '%" + part + "%' \r\n    OR lName LIKE '%" + part + "%' \r\n    OR Speaker.SpeakerExperianceInfo LIKE '%" + part + "%' \r\n    OR Speaker.topicDescription LIKE '%" + part + "%'\r\n)";
            return ReadTable(Q);

        }
        public object searchingTeamPage(string part)
        {
            String Q = "select commiteeId,commiteeName,CommitteeDescription from FestivalCommitees where commiteeName like '%" + part + "%' or CommitteeDescription like '%" + part + "%'\r\n";
            return ReadTable(Q);
        }
        //========================================================================
        //========================================================================
        //========================================================================
        //Analysts page 
        //PAYMENT ANALYSIS
        //chart one 
        // for all days and all rooms
        public object ongetFunctionChart1()
        {
            string Q = "select count(*)as[number of visitors], payment_method from used,payment,visitor \r\nwhere payment.payment_code=used.payment_code and visitor.national_id=used.visitor_id\r\ngroup by payment_method";
            return ReadTable(Q);
        }
        //for specific day and room 
        public object onpostFunctionChart1(int roomId, int day)
        {
            string Q = "select count(*)as[number of visitors], payment_method from used,payment,visitor,Rooms,visitors_room \r\nwhere payment.payment_code=used.payment_code and visitor.national_id=used.visitor_id and payment.fastival_day=" + day + "\r\nand visitor.national_id=visitors_room.visitor_id and Rooms.room_id=visitors_room.room_id and Rooms.room_id=" + roomId + "\r\ngroup by payment_method";
            return ReadTable(Q);
        }
        //========================Payment Money Per Method
        public object ongetFunctionChart2()
        {
            string Q = "select SUM(payment_fess)as [total money],payment_method from payment \r\ngroup by payment_method \r\n";
            return ReadTable(Q);
        }
        public object onpostFunctionChart2(int roomId, int day)
        {
            string Q = "select sum(payment_fess)as[total money], payment_method from used,payment,visitor,Rooms,visitors_room \r\nwhere payment.payment_code=used.payment_code and visitor.national_id=used.visitor_id and payment.fastival_day=" + day + "\r\nand visitor.national_id=visitors_room.visitor_id and Rooms.room_id=visitors_room.room_id and Rooms.room_id=" + roomId + "\r\ngroup by payment_method";
            return ReadTable(Q);
        }
        //===========================Festival Payment For Each Day Of The Week
        public object ongetFunctionChart3()
        {
            string Q = "select SUM(payment_fess)as [total money],payment.fastival_day from payment \r\ngroup by payment.fastival_day order by [total money]  ";
            return ReadTable(Q);
        }
        public object onpostFunctionChart3(int roomId)
        {
            string Q = "select sum(payment_fess)as[total money], payment.fastival_day from used,payment,visitor,Rooms,visitors_room \r\nwhere payment.payment_code=used.payment_code and visitor.national_id=used.visitor_id\r\nand visitor.national_id=visitors_room.visitor_id and Rooms.room_id=visitors_room.room_id and Rooms.room_id="+roomId+"\r\ngroup by fastival_day";

            return ReadTable(Q);
        }
        //==============================================================================
        //===================VISITORS ANALYSIS
        //Festival Attendence
        public object ongetFunctionChart4()
        {
            string Q = "select count(*),sex from visitor\r\ngroup by sex";
            return ReadTable(Q);
        }
        public object onpostFunctionChart4(int roomId,int day)
        {
            string Q = "select count(*),sex from visitors_room,visitor,Rooms \r\nwhere visitors_room.room_id=Rooms.room_id and visitors_room.visitor_id=visitor.national_id and \r\nRooms.room_id="+roomId+" and visitors_room.festivalDay="+day+"\r\ngroup by sex";

            return ReadTable(Q);
        }
        //===================
        // how did you know about us 
        public object ongetFunctionChart5()
        {
            string Q = "select count(*) , visitor.HowYouKnowUs from visitor\r\ngroup by HowYouKnowUs";
            return ReadTable(Q);
        }
        //====================
        //festival attendence
        public object ongetFunctionChart6()
        {
            string Q = "select count(*),sex from visitor\r\ngroup by sex";
            return ReadTable(Q);
        }
        public object onpostFunctionChart6(int roomId, int day)
        {
            string Q = "select count(*),sex from visitors_room,visitor,Rooms \r\nwhere visitors_room.room_id=Rooms.room_id and visitors_room.visitor_id=visitor.national_id and \r\nRooms.room_id=" + roomId + " and visitors_room.festivalDay=" + day + "\r\ngroup by sex";

            return ReadTable(Q);
        }
        //PromoCodes
        public object ReadAllTable(string table)
        {
            string Q = "select * from " + table;
            return ReadTable(Q);
        }
        
        public void InsertRowPromo(promocode pc)
        {
            string Q = "insert into PromoCodes values ('"+pc.PromoName+"', " + pc.DiscountPercent + ", " + pc.NumTicketsOffered + ","+pc.NumOfPassing+",'"+pc.AssignedTo+"',"+pc.NumTicketsOffered+")";
            excuteNonQuery(Q);
        }
        //tickets
        public object DisplayTickets()
        {
            string Q = "select ticket_id,Tickets.visitor_id,ticket_type,ticket_price,used.payment_code,number_of_passing,fastival_day,PromoCodeName from Tickets, used,payment where Tickets.ticket_id=used.tiket_id and used.payment_code=payment.payment_code";
            return ReadTable(Q);
        }
        //visitors
        public object DisplayVisitors()
        {
            string Q = "select fName,lName,age,visitor.national_id,Email,Phone_num,sex,user_password from visitor, PERSON where visitor.national_id = PERSON.National_id";
            return ReadTable(Q);
        }
        //Read visitor

        public visitor_edit ReadVisitorRow(string id)
        {
            visitor_edit v = new visitor_edit();
            DataTable dt = new DataTable();
            string Q = "Select * From users Where ID = '" + id + "'";
            dt =(DataTable)ReadTable(Q);
            v.fName = (string)dt.Rows[0]["fName"];
            v.lName = (string)dt.Rows[0]["lName"];
            v.national_id = (string)dt.Rows[0]["national_id"];
            v.email = (string)dt.Rows[0]["email"];
            v.phone_num = (string)dt.Rows[0]["phone_num"];
            v.password = (string)dt.Rows[0]["password"];
            return v;

        }
        //update visitor
        public void UpdateVisitorInfo(visitor_edit v)
        {
            string Q = "UPDATE Person SET fName = '"+v.fName+"', lName = '"+v.lName+"', Email ='"+v.email+"', Phone_num = '"+v.phone_num+"', user_password = '"+v.password+"' WHERE National_id = '"+v.national_id+"' ";
            excuteNonQuery(Q);
        }
        public void RemoveVisitor(string id)
        {
            string Q = "Delete From Person Where ID='"+id+"'";
            excuteNonQuery(Q);
        }
    }//

}
