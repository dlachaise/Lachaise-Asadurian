using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IPsychologistLogic
    {
        IEnumerable<Psychologist> GetAll();

        Psychologist Get(Guid id);

        void Update(Guid id, Psychologist Psychologist);
        void Delete(Guid id);
        Psychologist Create(Psychologist psyco);
        List<Psychologist> GetPsychoAvailable(IEnumerable<Psychologist> sublistPsyco, DateTime meetingDate);
        Psychologist OlderPsycho(List<Psychologist> sublistPsyco);
        public IEnumerable<Psychologist> GetByPathology(Guid pathology);


    }

}