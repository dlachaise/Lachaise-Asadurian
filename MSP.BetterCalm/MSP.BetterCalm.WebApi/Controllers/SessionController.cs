using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSP.BetterCalm.WebApi.Models;

namespace MSP.BetterCalm.WebApi.Controllers
{

    public class SessionController : BetterCalm
    {
        private readonly ISessionLogic sessionLogic;
        public SessionController(ISessionLogic logic) : base()
        {

            this.sessionLogic = logic;

        }
        [HttpPost]
        public IActionResult Post([FromBody] SessionDTO sessionDTO)
        {

            Session session = this.sessionLogic.Create(sessionDTO.toEntity());
            SessionDTO sessionAdded = new SessionDTO(session);

            return Ok(sessionAdded);

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Session session = this.sessionLogic.Get(id);

            if (session != null)
            {
                return Ok(new SessionDTO(session));
            }
            else
            {
                return NotFound("Session not found with id: " + id);

            }
        }
    }
}