using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface IPsychologistRepository
    {
        void Add(Psychologist entity);

        void Remove(Psychologist entity);

        void Update(Psychologist entity);

        IEnumerable<Psychologist> GetAll();

        Psychologist Get(Guid id);

        void Save();
    }
}
