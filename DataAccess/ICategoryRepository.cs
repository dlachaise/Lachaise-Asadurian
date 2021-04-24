using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface ICategoryRepository
    {
        void Add(Category entity);

        //void Remove(Category entity);
        IEnumerable<Category> GetAll();
        Category Get(Guid id);

        void Save();
    }
}
