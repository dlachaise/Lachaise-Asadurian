using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MSP.BetterCalm.DataAccess.Interface;

namespace MSP.BetterCalm.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class

    {

        private readonly DbSet<T> DbSet;
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.DbSet = context.Set<T>();
            this.context = context;
        }

        public void Create(T entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public T Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}