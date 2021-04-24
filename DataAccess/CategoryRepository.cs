using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CategoryRepository
    {

        protected DataContext Context { get; set; }
        public CategoryRepository(DataContext context)
        {
            Context = context;
        }

        public Category Get(Guid id)
        {
            return Context.Set<Category>().First(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return Context.Set<Category>().ToList();
        }

        public void Add(Category entity)
        {
            Context.Set<Category>().Add(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}


