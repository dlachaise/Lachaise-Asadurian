using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface IAudioLogic
    {
        IEnumerable<Audio> GetAll();

        // IEnumerable<Audio> GetByCategory(Guid idCategory);
        // IEnumerable<Audio> GetByPlaylist(Guid idPlaylist);

        Audio Get(Guid id);
        void Delete(Guid id);
        // void Create(Audio audio);

    }
}