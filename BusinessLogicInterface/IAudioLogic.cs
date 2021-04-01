using System;
using Domain;
using System.Collections.Generic;

namespace BusinessLogicInterface
{
    public interface IAudioLogic
    {
     IEnumerable<Audio> GetAll();

     IEnumerable<Audio> GetByCategory(Guid idCategory);
     IEnumerable<Audio> GetByPlaylist(Guid idPlaylist);

     Audio Get(Guid id);
    void Delete(Guid id);
     void Add(string Name, int Duration, string CreatorName, string ImageUrl, string AudioUrl,  bool IsActive  );
    
     
     
    }
}