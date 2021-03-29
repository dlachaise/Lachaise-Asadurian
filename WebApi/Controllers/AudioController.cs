using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AudioController
    {

        [HttpPost]
        public IActionResult AddAudio([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetByPlaylist([FromQuery] int playlistId)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAudio([FromQuery] int playListId)
        {
            return null;
        }

        [HttpPost]
        public IActionResult AddSong([FromBody]/*SongDTO */ int songId)
        {
            return null;
        }
    }
}
    }
}