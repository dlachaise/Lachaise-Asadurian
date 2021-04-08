using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface IAdministratorRepository
    {
        void Add(Administrator entity);

        void Remove(Administrator entity);

        void Update(Administrator entity);

        IEnumerable<Administrator> GetAll();

        Administrator Get(Guid id);

        void Save();
    }
}
