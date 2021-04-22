using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;
//using System.Collections.IEnumerable;
namespace BusinessLogic
{
    public class AudioLogic : IAudioLogic
    {

        private IAudioRepository iaudR;
        private AudioLogic audioLogic;
        private IAudioLogic iAudioLogic;

        public AudioLogic(IAudioRepository AudioR)
        {
            this.iaudR = AudioR;
        }

        public AudioLogic(AudioLogic aud)
        {
            this.audioLogic = aud;
        }
        public AudioLogic(IAudioLogic aud)
        {
            this.iAudioLogic = aud;
        }
        public AudioLogic(IAudioRepository repository, IAudioLogic audiosLogic)
        {
            this.iaudR = repository;
            this.iAudioLogic = audiosLogic;
        }

        /*public Audio Create(Administrator admin)
        {
            if (!ExistAdministrator(admin))
            {
                iaudR.Add(admin);
                iaudR.Save();
                return admin;
            }
            else
            {
                throw new Exception("The administrator already exists");
            }

        }
*/
      /*  private bool ExistAdministrator(Administrator administrator)
        {
            return iaudR.GetAll().Any(x => x.Email == administrator.Email);
        }*/

    public void CreateAudio(Audio audioToAdd){
            iaudR.Add(audioToAdd);
            iaudR.Save();
       }
        public void Delete(Guid id)
        {
            Audio audio = iaudR.Get(id);

            if (audio != null)
            {
                audio.IsActive= false;
                iaudR.Remove(audio);
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
            return this.iaudR.GetAll();
        }

        public IEnumerable<Audio> GetByCategory(Guid categoryId){
            return iaudR.GetByCategory(categoryId);
        }

       public IEnumerable<Audio> GetByPlaylist(Guid idPlaylist){
           return iaudR.GetByPlaylist(idPlaylist);
       }
    }
}