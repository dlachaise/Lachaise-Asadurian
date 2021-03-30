using System;

namespace Domain
{
    public class Consultation
    {
        public int Id { get; set; }
        public int MeetingType { get; set; }
        public string MeetingLink { get; set; }
        public DateTime Date {get; set;} 
        public string UserCompleteName { get; set; }

        public string UserBirthDate { get; set; }

        public string UserCel { get; set; }
        public string UserEmail { get; set; }

        public Psychologist Psychologist { get; set}

    }
}