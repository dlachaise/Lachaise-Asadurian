﻿using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class ConsultationLogic : IConsultationLogic
    {

        private IPsychologistLogic psychLogic;
        private IRepository<Consultation> iConsultationR;
        private ConsultationLogic consultationLogic;
        private IConsultationLogic iConsultationlogic;

        public ConsultationLogic(IRepository<Consultation> consultationR)
        {
            this.iConsultationR = consultationR;
        }
        public ConsultationLogic(IRepository<Consultation> consultationR, IPsychologistLogic iPsychoLogic)
        {
            this.iConsultationR = consultationR;
            this.psychLogic = iPsychoLogic;
        }

        public String CreateMeetingLink()
        {
            var meetingId = Guid.NewGuid();

            return "https://bettercalm.com.uy/meeting_id/" + meetingId;

        }

        public void CreateConsultation(Consultation consult, Guid pathologyId)
        {
            var listPsychologist = psychLogic.GetByPathology(pathologyId);
            if (listPsychologist == null)
            {
                throw new Exception("There are no psychologists available for this pathology");
            }
            else
            {
                var listPsychologistAvailable = psychLogic.GetPsychoAvailable(listPsychologist, consult.Date);

                if (listPsychologistAvailable == null)
                {
                    throw new Exception("There are no psychologists available for this date");
                }
                else
                {
                    var psychoForConsultation = psychLogic.OlderPsycho(listPsychologistAvailable);
                    consult.Psychologist = psychoForConsultation;
                    if (consult.Psychologist.MeetingType == 1)
                    {
                        consult.MeetingType = psychoForConsultation.MeetingType;
                        consult.MeetingAdress = psychoForConsultation.Address;
                    }
                    else
                    {
                        consult.MeetingType = psychoForConsultation.MeetingType;
                        consult.MeetingAdress = CreateMeetingLink();
                    }
                }

            }
            iConsultationR.Create(consult);
            iConsultationR.Save();
        }

        public Consultation Get(Guid id)
        {
            Consultation consultation = iConsultationR.Get(id);
            if (consultation != null)
            {
                return consultation;
            }
            else
            {
                throw new Exception("Consultation does not exist");
            }
        }

        public IEnumerable<Consultation> GetAll()
        {
            return this.iConsultationR.GetAll();
        }

    }
}