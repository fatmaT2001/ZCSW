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
            string Cstring = "Data Source=DESKTOP-7JS7BD2;Initial Catalog=project;Integrated Security=True";

            string Cstring = "Data Source=LAPTOP-TK7SBN2G;Initial Catalog=ZCW;Integrated Security=True";
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
            string Q = "select Speaker_National_id,PERSON.lName,midName,fName,category,topic,Speaker.SpeakerExperianceInfo,Speaker.topicDescription from PERSON, Speaker where Speaker.Speaker_National_id=PERSON.National_id";
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
        public object ongetFunctionChart4()
        {
            string Q = "select count(*),sex from visitor\r\ngroup by sex";
            return ReadTable(Q);
        }
        public object onpostFunctionChart4(int roomId, int day)
        {
            string Q = "select count(*),sex from visitors_room,visitor,Rooms \r\nwhere visitors_room.room_id=Rooms.room_id and visitors_room.visitor_id=visitor.national_id and \r\nRooms.room_id=" + roomId + " and visitors_room.festivalDay=" + day + "\r\ngroup by sex";

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
        public object onpostFunctionChart3(int roomId)
        {
            string Q = "select sum(payment_fess)as[total money], payment.fastival_day from used,payment,visitor,Rooms,visitors_room \r\nwhere payment.payment_code=used.payment_code and visitor.national_id=used.visitor_id\r\nand visitor.national_id=visitors_room.visitor_id and Rooms.room_id=visitors_room.room_id and Rooms.room_id=" + roomId + "\r\ngroup by fastival_day";
            return ReadTable(Q);
        }


        //=============================Visitor Functions ===========================================

        public void adduser(Person p, visitor v)
        {
            
            string Q = " Insert INTO Person Values ('" + p.ssn + "', '" + p.phonenum + "', '" + p.fname + "', '" + p.midname + "', '" + p.lname + "', '" + p.email + "', '" + p.password + "', " + p.usertyep + ") ";
            excuteNonQuery(Q);
            switch (p.usertyep)
            {
                case 0:

                    v.id = (int)maxIDVisitor();
                    string Q1 = " INSERT INTO VISITOR Visitor VALUES  ('" + p.ssn + "', " + v.age + ", '" + v.Gender + "')";
                    excuteNonQuery(Q1);
                    break;

                case 4:

                    string Q2 = " ";     //EDIT HERE
                    excuteNonQuery(Q2);
                    break;
            }


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

        public int getremainticket(string day, string type)
        {
            string Q = "SELECT number_of_tickets AS ticket_count\r\nFROM non_booked_ticket\r\nWHERE ticket_day = '" + day + "' AND ticket_type = '" + type + "';\r\n";
            return (int)ReadScaler(Q);
        }

        public void UpdateNumberOfTickets(int quantity, string dayAttending)
        {
            string Q = "UPDATE non_booked_ticket SET number_of_tickets = number_of_tickets + " + quantity + " WHERE ticket_day = " + dayAttending + "and  ticket_type = 'rgular'";
            excuteNonQuery(Q);
        }
        public int getbookedticket(string day, string type)
        {
            string Q = "SELECT COUNT(*) AS TicketCount FROM Tickets WHERE ticketday = '" + day + "' AND ticket_type = '" + type + "'";
            return (int)ReadScaler(Q);
        }




        public object Gettyep(string Email)
        {
            string Q = "SELECT userType FROM Person WHERE Email ='" + Email + "'";
            return ReadScaler(Q);
        }

        public bool CheckPassword(string Email, string password)
        {
            string Q = " Select user_password from Person  where Email= '"+ Email +"'";
            return (string)func2(Q) == password;
        }
        public object nextTicketID()
        {
            int m = -1;
            string Q = " Select COUNT(*) from Tickets ";
            m = (int)ReadScaler(Q);
            return m + 1;

        }
        public void InsertnewTicket(Ticket t)
        {
            t.ticketid = (int)nextTicketID();
            string Q = " INSERT INTO TICKETS VALUES ('" + t.ticketid + "', '" + t.tickettyep + "', " + t.promocode + ")";
            excuteNonQuery(Q);  
        }
        public object func2(string Q)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                object result = cmd.ExecuteScalar();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                con.Close();
                return ex;
            }
        }
    };
}



