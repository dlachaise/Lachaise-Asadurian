using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Category> Categories { get; set; }
    }
}