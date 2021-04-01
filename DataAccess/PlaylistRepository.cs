using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PlaylistRepository
    {

        protected DataContext Context { get; set; }
        public PlaylistRepository(DataContext context)
        {
            Context = context;
        }

        public Playlist Get(Guid id)
        {
            return Context.Set<Playlist>().First(x => x.Id == id);
        }

        public IEnumerable<Playlist> GetByCategory(Guid categoryId)
        {
            var category = Context.Set<Category>().Include(x => x.Playlists).Where(x => x.Id == categoryId).First();
            return category.Playlists.ToList();
        }

        public IEnumerable<Playlist> GetAll()
        {
            return Context.Set<Playlist>().ToList();
        }

        public void Add(Playlist entity)
        {
            Context.Set<Playlist>().Add(entity);
        }




        public void Save()
        {
            Context.SaveChanges();
        }
    }
}


