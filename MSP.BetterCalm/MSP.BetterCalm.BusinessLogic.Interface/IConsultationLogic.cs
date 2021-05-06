using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IConsultationLogic
    {
        IEnumerable<Consultation> GetAll();
        Consultation Get(Guid id);

        Consultation Create(Consultation consultation, Guid pathologyId);

    }
}