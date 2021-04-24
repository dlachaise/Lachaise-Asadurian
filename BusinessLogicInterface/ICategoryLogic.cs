using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface ICategoryLogic
    {
     IEnumerable<Category> GetAll();
     Category Get(Guid id);    
     
    }
}