using System;

namespace MSP.BetterCalm.Domain
{
    public class Consultation
    {
        public Guid Id { get; set; }
        public int MeetingType { get; set; }
        public string MeetingAdress { get; set; }
        public DateTime Date { get; set; }
        public string UserCompleteName { get; set; }

        public string UserBirthDate { get; set; }

        public string UserCel { get; set; }
        public string UserEmail { get; set; }

        public Psychologist Psychologist { get; set; }

    }
}