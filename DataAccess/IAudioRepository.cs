using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface IAudioRepository
    {
        void Add(Audio entity);

        void Remove(Audio entity);

        //void Update(Audio entity);

        IEnumerable<Audio> GetAll();
        IEnumerable<Audio> GetByCategory(Guid categoryId);

        Audio Get(Guid id);

        void Save();
    }
}
