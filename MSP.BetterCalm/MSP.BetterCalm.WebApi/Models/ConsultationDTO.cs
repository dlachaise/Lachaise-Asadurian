using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;
namespace MSP.BetterCalm.WebApi.Models
{
    public class ConsultationDTO
    {
        public Guid Id { get; set; }
        public int MeetingType { get; set; }
        public string MeetingAdress { get; set; }
        public DateTime Date { get; set; }
        public string UserCompleteName { get; set; }

        public string UserBirthDate { get; set; }
        public Guid PathologyId { get; set; }

        public string UserCel { get; set; }
        public string UserEmail { get; set; }
        public Psychologist Psychologist { get; set; }

        public ConsultationDTO(Consultation consultation)
        {

            this.Id = consultation.Id;
            this.MeetingType = consultation.MeetingType;
            this.MeetingAdress = consultation.MeetingAdress;
            this.Date = consultation.Date;
            this.UserCompleteName = consultation.UserCompleteName;
            this.UserBirthDate = consultation.UserBirthDate;
            this.UserCel = consultation.UserCel;
            this.UserEmail = consultation.UserEmail;
            this.Psychologist = consultation.Psychologist;

        }

        public ConsultationDTO()
        {

        }

        public Consultation toEntity() => new Consultation
        {

            Id = this.Id,
            MeetingType = this.MeetingType,
            MeetingAdress = this.MeetingAdress,
            Date = this.Date,
            UserCompleteName = this.UserCompleteName,
            UserBirthDate = this.UserBirthDate,
            UserEmail = this.UserEmail,
            UserCel = this.UserCel,
            Psychologist = this.Psychologist,

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is ConsultationDTO model)
            {

                if (model.MeetingAdress != null)
                    result = this.MeetingAdress.Equals(model.MeetingAdress);
                if (model.Date != null)
                    result = this.Date.Equals(model.Date);
                if (model.Psychologist != null)
                    result = this.Psychologist.Equals(model.Psychologist);
                if (model.UserCompleteName != null)
                    result = this.UserCompleteName.Equals(model.UserCompleteName);

            }

            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }


}
