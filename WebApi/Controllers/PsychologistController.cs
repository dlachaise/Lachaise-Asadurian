using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class PsicologoController
    {
        [HttpPost]
        public IActionResult AddPsycologhyst([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }

        [HttpPut]
        public IActionResult Update([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }


        [HttpGet]
        public IActionResult GetAll(sbyte)
        {
            return null;
        }


        [HttpGet]
        public IActionResult GetById([FromQuery] int psycId)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetByEmail([FromQuery] int psycId)
        {
            //verificar contrasena
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrator([FromQuery] int psycId)
        {
            return null;
        }

    }
}