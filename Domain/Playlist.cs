using System;
using System.Collections.Generic;

namespace Domain
{
    public class Playlist
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
        public string ImageUrl {get; set;}
        public List<Audio> Audios {get; set;}
    }
}