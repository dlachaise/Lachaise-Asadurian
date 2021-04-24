using System;
using System.Collections.Generic;
using Domain;
using BusinessLogicInterface;
using System.Linq;
using DataAccess;

namespace BusinessLogic
{
    public class PsychologistLogic : IPsychologistLogic
    {
        private IPsychologistRepository psycDA;
        private PsychologistLogic psycoLogic;
        private IPsychologistLogic iPsycLogic;


        public PsychologistLogic(IPsychologistRepository repository, IPsychologistLogic psycsLogic)
        {
            this.psycDA = repository;
            this.iPsycLogic = psycsLogic;
        }

        public Psychologist Create(Psychologist psyc)
        {
            psycDA.Add(psyc);
            psycDA.Save();
            return psyc;
        }

        public void Delete(Guid id)
        {
            Psychologist psyc = psycDA.Get(id);

            if (psyc != null)
            {
                psyc.IsActive = false;
                psycDA.Remove(psyc);
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

        // public IEnumerable<Psychologist> GetByDate(IEnumerable<Psychologist> sublistPsyco)
        // {
        //     // DateTime today = DateTime.Now;
        //     // today.AddDays(1);
        //     // return sublistPsyco.Where(x => (x.getNextDayAvailable() < today.AddDays(7)));
        // }
    }
}