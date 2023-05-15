namespace ZewailCiryScienceWeek.DataClasses
{
    public class FestivalCommitteeClass
    {
        public int CommitteeId { get; set; }
        public string CommitteeName { get; set; }
        public string CommitteeDescription { get; set; }

        public FestivalCommitteeClass(int committeeId = 0, string committeeName = "", string committeeDescription = "")
        {
            CommitteeId = committeeId;
            CommitteeName = committeeName;
            CommitteeDescription = committeeDescription;
        }
    }
}
