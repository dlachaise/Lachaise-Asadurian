using System;

using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}