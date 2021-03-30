using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpPost]
        public IActionResult AddAdministrator([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] string name, string description, string imageUrl)
        {
            return null;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return null;
        }


        [HttpGet("{id}")]
        public IActionResult GetById([FromQuery] int adminId)
        {
            return null;
        }

        [HttpGet]
        public IActionResult GetByEmail([FromQuery] int adminId)
        {
            //verificar contrasena
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdministrator([FromQuery] int adminId)
        {
            return null;
        }


    }
}