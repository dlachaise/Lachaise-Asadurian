using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;


namespace MSP.BetterCalm.BusinessLogic
{
    public class AudioLogic : IAudioLogic
    {

        private IRepository<Audio> iaudR;
        private IRepository<Playlist> iplayR;
        private IRepository<Category> icatR;


        public AudioLogic(IRepository<Audio> AudioR)
        {
            this.iaudR = AudioR;
        }

        public void Delete(Guid id)
        {
            Audio audio = iaudR.Get(id);

            if (audio != null)
            {
                audio.IsActive = false;
                iaudR.Delete(audio);
                iaudR.Save();
            }
            else
            {
                throw new Exception("Audio does not exist");
            }

        }

        public Audio Get(Guid id)
        {
            Audio audio = iaudR.Get(id);
            if (audio != null && audio.IsActive == true)
            {
                return audio;
            }
            else
            {
                throw new Exception("Audio does not exist");
            }
        }

        public IEnumerable<Audio> GetAll()
        {
            return this.iaudR.GetAll().Where(y => y.IsActive == true);
        }

<<<<<<< HEAD
        public Audio Create(Audio audio)
        {
            iaudR.Create(audio);
            iaudR.Save();
            return audio;
        }
//PROBAR ESTAS DOS
        public IEnumerable<Audio> GetByPlaylist(Guid playlistId)
        {
            Playlist playlist = iplayR.Get(playlistId);
            if (playlist != null)
            {
                return this.GetAll().Where(audio => audio.Playlists.Contains(playlist));
            }
            return null;
        }

        public IEnumerable<Audio> GetByCategory(Guid categoryId)
        {
            Category category = icatR.Get(categoryId);
            if (category != null)
            {
                return this.GetAll().Where(audio => audio.Categories.Contains(category));
            }
            return null;
        }
=======
>>>>>>> 6ac6082973ab956cf6c0d80d21a11470883cf905
    }
}