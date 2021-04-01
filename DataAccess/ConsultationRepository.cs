using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ConsultationRepository
    {

        protected DataContext Context { get; set; }
        public ConsultationRepository(DataContext context)
        {
            Context = context;
        }

        public Consultation Get(Guid id)
        {
            return Context.Set<Consultation>().First(x => x.Id == id);
        }

        public IEnumerable<Consultation> GetAll()
        {
            return Context.Set<Consultation>().ToList();
        }

        public void Add(Consultation entity)
        {
            Context.Set<Consultation>().Add(entity);
        }

        public void Remove(Consultation entity)
        {
            Context.Set<Consultation>().Remove(entity);
        }


        public void Save()
        {
            Context.SaveChanges();
        }
    }
}


