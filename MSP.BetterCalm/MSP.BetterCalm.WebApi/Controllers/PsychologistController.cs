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
    public class PsychologistController : BetterCalm
    {
        private readonly IPsychologistLogic psychologistLogic;
        public PsychologistController(IPsychologistLogic logic) : base()
        {

            this.psychologistLogic = logic;

        }

        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<PsychologistDTO> Psychologists = this.psychologistLogic.GetAll().Select(psycho => new PsychologistDTO(psycho));

            return Ok(Psychologists);

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Psychologist psycho = this.psychologistLogic.Get(id);

            if (psycho != null)
            {
                return Ok(new PsychologistDTO(psycho));
            }
            else
            {
                return NotFound("Psychologist not found with id: " + id);

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PsychologistDTO psychoDTO)
        {

            Psychologist psycho = this.psychologistLogic.Create(psychoDTO.toEntity());
            PsychologistDTO psychoAdded = new PsychologistDTO(psycho);

            return Ok(psychoAdded);

        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] PsychologistDTO psychoDTO)
        {
            try
            {
                Psychologist psycho = psychoDTO.toEntity();
                psychologistLogic.Update(id, psycho);
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
                psychologistLogic.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }


        }

    }
}