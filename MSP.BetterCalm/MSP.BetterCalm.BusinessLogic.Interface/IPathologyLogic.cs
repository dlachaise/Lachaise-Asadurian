using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
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