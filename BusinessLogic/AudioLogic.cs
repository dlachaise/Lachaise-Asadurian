using System;
using System.Collections.Generic;
using Domain;
using DataAccess;
using BusinessLogicInterface;
using System.Linq;
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
        public AudioLogic(IAdudioLogic aud)
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

       /* public void Update(Guid id, Audio updatedAudio)
        {

            Audio audio = iaudR.Get(id);

            if (audio != null)
            {
                audio.Name = updatedAudio.Name;
                audio.Duration = updatedAudio.Duration;
                audio.CreatorName = updatedAudio.CreatorName;
                audio.ImageUrl = updatedAudio.ImageUrl;
                audio.AudioUrl = updatedAudio.AudioUrl;

                iaudR.Update(audio);
                iaudR.Save();
            }
            else
            {
                throw new Exception("The Audio doesn't exists");
            }
        }*/

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
    }
}