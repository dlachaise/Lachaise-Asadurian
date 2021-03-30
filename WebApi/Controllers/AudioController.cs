using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AudioController
    {

        [HttpPost]
        public IActionResult AddAudio([FromBody] string name, string description, string imageUrl)
        {
            //si tiene categoria va suelto, si tiene categoria y playlist va solo a la playlist
            return null;
        }

        [HttpGet]
        public IActionResult GetByPlaylist([FromQuery] int playlistId)
        {
            return null;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAudio([FromQuery] int playListId)
        {
            return null;
        }
    }
}

