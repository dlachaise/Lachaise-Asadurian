using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IAdministratorLogic
    {
        IEnumerable<Administrator> GetAll();

        Administrator Get(Guid id);

        void Update(Guid id, Administrator admin);
        void Delete(Guid id);
        void Create(Administrator admin);


    }
}