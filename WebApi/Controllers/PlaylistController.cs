using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PlaylistController
    {

        [HttpPost]
        public IActionResult AddPlaylist([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetByCategorie([FromQuery] int categorieId)
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlaylist([FromQuery] int playListId)
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