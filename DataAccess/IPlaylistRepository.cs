using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface IPlaylistRepository
    {
        void Add(Playlist entity);

        void Remove(Playlist entity);
        IEnumerable<Playlist> GetAll();
        /*IEnumerable<Playlist> GetByCategory(Guid categoryId);
        IEnumerable<Playlist> GetByPlaylist(Guid idPlaylist);*/

        Playlist Get(Guid id);

        void Save();
    }
}
