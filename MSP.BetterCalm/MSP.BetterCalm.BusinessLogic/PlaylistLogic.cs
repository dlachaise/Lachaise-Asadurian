using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistLogic : IPlaylistLogic
    {
        private IRepository<Playlist> iPlayR;

        public PlaylistLogic(IRepository<Playlist> PlayR)
        {
            this.iPlayR = PlayR;
        }

        public void Create(Playlist playlistToAdd)
        {
            iPlayR.Create(playlistToAdd);
            iPlayR.Save();
        }
        public void Delete(Guid id)
        {
            Playlist playL = iPlayR.Get(id);

            if (playL != null)
            {
                iPlayR.Delete(playL);
                iPlayR.Save();
            }
            else
            {
                throw new Exception("Playlist does not exist");
            }

        }

        public Playlist Get(Guid id)
        {
            Playlist playL = iPlayR.Get(id);
            if (playL != null)
            {
                return playL;
            }
            else
            {
                throw new Exception("Playlist does not exist");
            }
        }

        public IEnumerable<Playlist> GetAll()
        {
            return this.iPlayR.GetAll();
        }
    }
}