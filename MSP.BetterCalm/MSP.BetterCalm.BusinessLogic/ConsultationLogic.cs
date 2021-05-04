using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;

namespace MSP.BetterCalm.BusinessLogic
{
    public class ConsultationLogic : IConsultationLogic
    {

        private IPsychologistLogic psychLogic; //probandooooooooooooooooo
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

                if(listPsychologistAvailable == null){
                     throw new Exception("There are no psychologists available for this date");
                }else {
                    var psychoForConsultation = psychLogic.OlderPsycho(listPsychologistAvailable);
                     consult.Psychologist = psychoForConsultation;
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






        /*public void CreateCategory(Playlist playlistToAdd){
                iCategoryR.Add(playlistToAdd);
                iCategoryR.Save();
           }
            public void Delete(Guid id)
            {
                Playlist playL = iCategoryR.Get(id);

                if (playL != null)
                {
                   // playL.IsActive= false;
                    iCategoryR.Remove(playL);
                    iCategoryR.Save();
                }
                else
                {
                    throw new Exception("Playlist does not exist");
                }

            }*/
    }
}