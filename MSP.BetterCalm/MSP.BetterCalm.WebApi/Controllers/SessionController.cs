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
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : BetterCalm
    {
        private readonly ISessionLogic sessionLogic;
        public SessionController(ISessionLogic logic) : base()
        {

            this.sessionLogic = logic;

        }

        [HttpPost]
        public IActionResult Login([FromBody] AdministratorLoginDTO admLogin)
        {
            var token = sessionLogic.CreateToken(admLogin.Email, admLogin.Password);
            if (token == null)
            {
                return BadRequest("Invalid Email or Password");
            }
            return Ok(token);
        }

    }
}