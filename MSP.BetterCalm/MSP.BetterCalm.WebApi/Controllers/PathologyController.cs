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
    public class PathologyController : BetterCalm
    {
        private readonly IPathologyLogic pathologyLogic;

        public PathologyController(IPathologyLogic logic) : base()
        {
            this.pathologyLogic = logic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PathologyDTO> Pathologies = this.pathologyLogic.GetAll().Select(pat => new PathologyDTO(pat));

            return Ok(Pathologies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Pathology pathology = this.pathologyLogic.Get(id);

            if (pathology != null)
            {
                return Ok(new PathologyDTO(pathology));
            }
            else
            {
                return NotFound("Pathology not found with id: " + id);

            }
        }
    }
}








