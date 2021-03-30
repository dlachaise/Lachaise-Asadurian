namespace Domain
{
    public class Consultation
    {
        public int Id { get; set; }
        public int Format { get; set; }
        public string Address { get; set; }
        public string UserCompleteName { get; set; }

        public string UserBirthDate { get; set; }

        public string UserCel { get; set; }

         public Psychologist Psychologist { get; set}

    }
}