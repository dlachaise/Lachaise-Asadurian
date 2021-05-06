using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IAudioLogic
    {
        IEnumerable<Audio> GetAll();

        IEnumerable<Audio> GetByCategory(Guid categoryId);
        IEnumerable<Audio> GetByPlaylist(Guid playlistId);

        Audio Get(Guid id);
        void Delete(Guid id);
        Audio Create(Audio audio);

    }
}