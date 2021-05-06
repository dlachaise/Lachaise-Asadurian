using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface ICategoryLogic
    {
        IEnumerable<Category> GetAll();
        Category Get(Guid id);

    }
}