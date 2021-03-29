using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ConsultationController
    {
        [HttpPost]
        public IActionResult AddConsultation([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetNextDateAvailableByPsyc([FromQuery] int psycologhisId)
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