using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IConsultationLogic
    {
        IEnumerable<Consultation> GetAll();
        Consultation Get(Guid id);

    }
}