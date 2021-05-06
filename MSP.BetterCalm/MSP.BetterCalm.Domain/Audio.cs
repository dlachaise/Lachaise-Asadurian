using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Audio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }

        public bool IsActive { get; set; }

        public List<Playlist> Playlists { get; set; }
        public List<Category> Categories { get; set; }




        public Audio()
        {
            Id = Guid.NewGuid();
        }
    }
}