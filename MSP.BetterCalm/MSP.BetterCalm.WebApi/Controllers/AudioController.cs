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

    public class AudioController : BetterCalm
    {
        private readonly IAudioLogic audioLogic;
        private readonly IPlaylistLogic playlistLogic;
        private readonly ICategoryLogic categoryLogic;
        public AudioController(IAudioLogic logic) : base()
        {

            this.audioLogic = logic;

        }

        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<AudioDTO> Audios = this.audioLogic.GetAll().Select(audio => new AudioDTO(audio));

            return Ok(Audios);

        }

        [HttpGet("byPlaylist/{id}")]
        public IActionResult GetAudiosByPlaylist(Guid playlistId)
        {
            IEnumerable<AudioDTO> Audios = this.audioLogic.GetByPlaylist(playlistId).Select(audio => new AudioDTO(audio));
            if (Audios != null)
            {
                return Ok(Audios);
            }
            else
            {
                return BadRequest("The playlist doesn't have any audio");
            }
        }

        [HttpGet("byCategory/{id}")]
        public IActionResult GetAudiosByCategory(Guid categoryId)
        {
            IEnumerable<AudioDTO> Audios = this.audioLogic.GetByCategory(categoryId).Select(audio => new AudioDTO(audio));
            if (Audios != null)
            {
                return Ok(Audios);
            }
            else
            {
                return BadRequest("The Category doesn't have any audio");
            }
        }



        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Audio audio = this.audioLogic.Get(id);

            if (audio != null)
            {
                return Ok(new AudioDTO(audio));
            }
            else
            {
                return NotFound("Audio not found with id: " + id);

            }
        }

        [HttpPost]
        [AuthorizationFilter]
        public IActionResult Post([FromBody] AudioDTO audioDTO)
        {

            Audio audio = this.audioLogic.Create(audioDTO.toEntity());
            AudioDTO audioAdded = new AudioDTO(audio);

            return Ok(audioAdded);

        }


        [HttpDelete("{id}")]
        [AuthorizationFilter]
        public IActionResult Delete(Guid id)
        {
            try
            {
                audioLogic.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }


        }

    }
}