using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class PlaylistLogic : IPlaylistLogic
    {
        private IRepository<Playlist> iPlayR;
        private IRepository<Category> iCatR;

        public PlaylistLogic(IRepository<Playlist> PlayR)
        {
            this.iPlayR = PlayR;
        }

        public Playlist Create(Playlist playlistToAdd)
        {
            iPlayR.Create(playlistToAdd);
            iPlayR.Save();
            return playlistToAdd;
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
   
        public IEnumerable<Playlist> GetByCategory(Guid categoryId)
        {
            Category category = iCatR.Get(categoryId);
            if (category != null)
            {
                return this.GetAll().Where(play => play.Categories.Contains(category));
            }
            return null;
        }
    }
}