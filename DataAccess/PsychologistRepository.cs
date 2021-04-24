using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PsychologistRepository : IPsychologistRepository
    {

        protected DataContext Context { get; set; }
        public PsychologistRepository(DataContext context)
        {
            Context = context;
        }

        public Psychologist Get(Guid id)
        {
            return Context.Set<Psychologist>().First(x => x.Id == id);
        }

        public IEnumerable<Psychologist> GetAll()
        {
            return Context.Set<Psychologist>().ToList();
        }

        public void Add(Psychologist entity)
        {
            Context.Set<Psychologist>().Add(entity);
        }

        public void Remove(Psychologist entity)
        {
            Context.Set<Psychologist>().Remove(entity);
        }

        public void Update(Psychologist entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}


