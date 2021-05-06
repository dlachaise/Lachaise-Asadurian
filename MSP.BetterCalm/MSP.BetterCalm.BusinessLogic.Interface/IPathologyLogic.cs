using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IPathologyLogic
    {
            IEnumerable<Pathology> GetAll();
            Pathology Get(Guid id);


    }
}