using System;
using System.Collections.Generic;
using Domain;

namespace DataAccess
{
    public interface IAudioRepository
    {
        void Add(Audio entity);

        void Remove(Audio entity);
        IEnumerable<Audio> GetAll();
        IEnumerable<Audio> GetByCategory(Guid categoryId);
        IEnumerable<Audio> GetByPlaylist(Guid idPlaylist);

        Audio Get(Guid id);

        void Save();
    }
}
