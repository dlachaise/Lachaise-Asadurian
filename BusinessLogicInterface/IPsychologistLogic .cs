using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPsychologistLogic
    {
        IEnumerable<Psychologist> GetAll();
        Psychologist GetByPathologyAndExpert(Guid pathologyId);

        Psychologist Get(Guid id);

        void Update(Psychologist Psychologist);
        void Delete(Guid id);
        void Add(string Name, string MeetingType, string Address, bool IsActive);

    }

}