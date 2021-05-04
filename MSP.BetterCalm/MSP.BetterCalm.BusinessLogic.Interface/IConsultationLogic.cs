using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category Get(Guid id);

    }
}