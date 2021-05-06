using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

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