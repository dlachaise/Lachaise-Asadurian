using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IPathologyLogic
    {
        public interface IPathologyLogic
        {
            IEnumerable<Pathology> GetAll();
            Pathology Get(Guid id);

        }

    }
}