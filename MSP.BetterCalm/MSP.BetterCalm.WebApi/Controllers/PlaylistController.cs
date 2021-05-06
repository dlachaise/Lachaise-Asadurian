using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebApi.Models;
using MSP.BetterCalm.WebApi.Filters;
namespace MSP.BetterCalm.WebApi.Controllers

{
    [Route("api/[controller]")]
    public class PlaylistController : BetterCalm
    {
        private readonly IPlaylistLogic playlistLogic;

        public PlaylistController(IPlaylistLogic logic) : base()
        {
            this.playlistLogic = logic;
        }

        [HttpGet("byCategory/{id}")]
        public IActionResult GetByCategory(Guid categoryId)
        {
            IEnumerable<PlaylistDTO> playlist = this.playlistLogic.GetByCategory(categoryId).Select(play => new PlaylistDTO(play));

            return Ok(playlist);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Playlist playlist = this.playlistLogic.Get(id);

            if (playlist != null)
            {
                return Ok(new PlaylistDTO(playlist));
            }
            else
            {
                return NotFound("Playlist not found with id: " + id);

            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] PlaylistDTO playlistDTO)
        {

            Playlist playlist = this.playlistLogic.Create(playlistDTO.toEntity());
            PlaylistDTO playlistAdded = new PlaylistDTO(playlist);

            return Ok(playlistAdded);

        }
    }
}








