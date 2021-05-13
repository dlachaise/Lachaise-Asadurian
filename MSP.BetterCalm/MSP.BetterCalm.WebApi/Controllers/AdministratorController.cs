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
    public class AdministratorController : BetterCalm
    {
        private readonly IAdministratorLogic administratorLogic;
        public AdministratorController(IAdministratorLogic logic) : base()
        {

            this.administratorLogic = logic;

        }

        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<AdministratorDTO> Administrators = this.administratorLogic.GetAll().Select(adm => new AdministratorDTO(adm));

            return Ok(Administrators);

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Administrator admin = this.administratorLogic.Get(id);

            if (admin != null)
            {
                return Ok(new AdministratorDTO(admin));
            }
            else
            {
                return NotFound("Adminstrator not found with id: " + id);

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdministratorDTO adminDTO)
        {

            Administrator admin = this.administratorLogic.Create(adminDTO.toEntity());
            AdministratorDTO adminAdded = new AdministratorDTO(admin);

            return Ok(adminAdded);

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] AdministratorDTO adminDTO)
        {
            try
            {
                Administrator admin = adminDTO.toEntity();
                administratorLogic.Update(id, admin);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                administratorLogic.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }


        }

    }
}