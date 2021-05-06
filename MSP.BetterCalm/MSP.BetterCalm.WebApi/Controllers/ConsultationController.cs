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

    public class ConsultationController : BetterCalm
    {
        private readonly IConsultationLogic consultationLogic;
        public ConsultationController(IConsultationLogic logic) : base()
        {

            this.consultationLogic = logic;

        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Consultation consultation = this.consultationLogic.Get(id);

            if (consultation != null)
            {
                return Ok(new ConsultationDTO(consultation));
            }
            else
            {
                return NotFound("Consultation not found with id: " + id);

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ConsultationDTO consultationDTO)
        {
            Consultation consultation = this.consultationLogic.Create(consultationDTO.toEntity(), consultationDTO.PathologyId);
            ConsultationDTO consultationAdded = new ConsultationDTO(consultation);

            return Ok(consultationAdded);

        }

    }
}