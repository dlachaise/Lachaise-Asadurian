using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;
using MSP.BetterCalm.DataAccess;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private IRepository<Psychologist> psycDA;


        public PsychologistLogic(IRepository<Psychologist> repository)
        {
            this.psycDA = repository;
        }

        public Psychologist Create(Psychologist psyc)
        {
            psycDA.Create(psyc);
            psycDA.Save();
            return psyc;
        }

        public void Delete(Guid id)
        {
            Psychologist psyc = psycDA.Get(id);

            if (psyc != null)
            {
                psyc.IsActive = false;
                psycDA.Delete(psyc);
                psycDA.Save();
            }
            else
            {
                throw new Exception("Psychologist does not exist");
            }

        }

        public void Update(Guid id, Psychologist updatedPsychologyst)
        {

            Psychologist psyco = psycDA.Get(updatedPsychologyst.Id);

            if (psyco != null)
            {
                psyco.Update(updatedPsychologyst);
                psycDA.Update(updatedPsychologyst);
                psycDA.Save();
            }
            else
            {
                throw new Exception("The psychologist doesn't exists");
            }
        }

        public Psychologist Get(Guid id)
        {
            Psychologist psyc = psycDA.Get(id);
            if (psyc != null && psyc.IsActive == true)
            {
                return psyc;
            }
            else
            {
                throw new Exception("Psychologist does not exist");
            }
        }

        public IEnumerable<Psychologist> GetAll()
        {
            return psycDA.GetAll();
        }


        public IEnumerable<Psychologist> GetByPathology(Guid pathology)
        {
            return psycDA.GetAll().Where(psyc => psyc.Pathologies.Any(pat => pat.Id == pathology));

        }

        public List<Psychologist>/*IEnumerable<Psychologist>*/ GetPsychoAvailable(IEnumerable<Psychologist> sublistPsyco, DateTime meetingDate)
        {

            List<Psychologist> psychosAvailable = new List<Psychologist>();
            foreach (var pyscho in sublistPsyco)
            {
                SortedList<DateTime, int> aux = pyscho.MeetingList;
                foreach (var meeting in aux)
                {

                    int res = DateTime.Compare(meeting.Key, meetingDate);
                    if (res == 0)
                    {
                        if (meeting.Value <= 5)
                        {
                            psychosAvailable.Add(pyscho);
                        }
                    }
                    else if (res < 0)
                    {
                        aux.Add(meetingDate, +1);
                        break;
                    }
                }
            }
            return psychosAvailable;

        }

        public Psychologist OlderPsycho(List<Psychologist> sublistPsyco)
        {
            DateTime dateFstPsycho = sublistPsyco.First().StartDate;
            Psychologist ret = new Psychologist();

            foreach (var psycho in sublistPsyco)
            {
                int result = DateTime.Compare(psycho.StartDate, dateFstPsycho);
                if (result < 0)
                {
                    dateFstPsycho = psycho.StartDate;
                    ret = psycho;
                }
            }
            return ret;
        }
    }
}