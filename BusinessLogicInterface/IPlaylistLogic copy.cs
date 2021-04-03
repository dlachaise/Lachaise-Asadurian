using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPlaylistLogicj
    {
        IEnumerable<Playlist> GetAll();

        IEnumerable<Playlist> GetByCategory(Guid idCategory);

        Playlist Get(Guid id);
        void Delete(Guid id);
        void Add(string Name, int Duration, string CreatorName, string ImageUrl, string PlaylistUrl, bool IsActive);



    }
}