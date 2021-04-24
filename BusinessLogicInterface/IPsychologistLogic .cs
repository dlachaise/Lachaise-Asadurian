using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        IEnumerable<Psychologist> GetAll();
        //  Psychologist GetByPathologyAndExpert(Guid pathologyId);

        Psychologist Get(Guid id);

        void Update(Guid id, Psychologist Psychologist);
        void Delete(Guid id);
        Psychologist Create(Psychologist psyco);

    }

}