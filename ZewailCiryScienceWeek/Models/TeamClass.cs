namespace ZewailCiryScienceWeek.DataClasses
{
    public class TeamClass
    {
        public string TeamMemberNationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public string TeamMemberPicture { get; set; }
        public int CommitteeId { get; set; }
        public string CommitteeName { get; set; }
        public List<string> SocialMediaLinks { get; set; }

        public TeamClass(string teamMemberNationalId="", string firstName="", string lastName="", string middleName = "", string position = "", int committeeId=0,string name="")
        {
            TeamMemberNationalId = teamMemberNationalId;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Position = position;
            TeamMemberPicture = "";
            CommitteeId = committeeId;
            SocialMediaLinks = new List<string>();
            CommitteeName = name;
        }
    }
}
