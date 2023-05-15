namespace ZewailCiryScienceWeek.DataClasses
{
    public class SpeakerClass
    {
            public string SpeakerNationalId { get; set; }
            public string PhoneNumber { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string FirstName { get; set; }
            public string Email { get; set; }
            public string Category { get; set; }
            public string Topic { get; set; }
            public string Topicdescription { get; set; }
            public string SpeakerExperienceInfo { get; set; }
            public string SpeakerPicture { get; set; }
            public List<string> SocialMediaLinks { get; set; }

            public SpeakerClass(string speakerNationalId="", string phoneNumber = "", string lastName = "", string middleName = "",
                           string firstName = "", string email = "", string category = "", string topic = "", string topicdescription = "",
                           string speakerExperienceInfo = "", string speakerPicture= "")
            {
                SpeakerNationalId = speakerNationalId ?? "";
                PhoneNumber = phoneNumber ?? "";
                LastName = lastName ?? "";
                MiddleName = middleName ?? "";
                FirstName = firstName ?? "";
                Email = email ?? "";
                Category = category ?? "";
                Topic = topic ?? "";
                Topicdescription = topicdescription ?? "";
                SpeakerExperienceInfo = speakerExperienceInfo ?? "";
                SpeakerPicture = speakerPicture ?? "";
                SocialMediaLinks = new List<string>();
        }
    }
    
}
