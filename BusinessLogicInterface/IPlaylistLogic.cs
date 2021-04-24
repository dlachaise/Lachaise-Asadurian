using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IPlaylistLogic
    {
     IEnumerable<Playlist> GetAll();

     /*IEnumerable<Playlist> GetByCategory(Guid idCategory);
     IEnumerable<Playlist> GetByPlaylist(Guid idPlaylist);*/


     Playlist Get(Guid id);
     void Delete(Guid id);
     //void CreateAudio(Playlist playL);
     
     
    }
}