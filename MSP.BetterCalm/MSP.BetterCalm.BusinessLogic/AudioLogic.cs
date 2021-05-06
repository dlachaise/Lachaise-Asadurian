using System;
using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using MSP.BetterCalm.Domain;
//using System.Collections.IEnumerable;


namespace MSP.BetterCalm.BusinessLogic
{
    public class AudioLogic : IAudioLogic
    {

        private IRepository<Audio> iaudR;

        public AudioLogic(IRepository<Audio> AudioR)
        {
            this.iaudR = AudioR;
        }
        public void CreateAudio(Audio audioToAdd)
        {
            iaudR.Create(audioToAdd);
            iaudR.Save();
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
            return this.iaudR.GetAll();
        }

    }

}