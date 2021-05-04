using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {

        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Guid id);
        IEnumerable<T> GetAll();
        void Save();

    }
}
