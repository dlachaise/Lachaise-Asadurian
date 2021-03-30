using System;
using System.Collections.Generic;

namespace Domain
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}