using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IAdministratorLogic
    {
        IEnumerable<Administrator> GetAll();

        Administrator Get(Guid id);

        void Update(Guid id, Administrator admin);
        void Delete(Guid id);
        Administrator Create(Administrator admin);


    }
}