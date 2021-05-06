using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebApi.Models;
using System.Threading.Tasks;
namespace MSP.BetterCalm.WebApi.Models
{
    public class AdministratorLoginDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public AdministratorLoginDTO(Administrator adm)
        {
            this.Email = adm.Email;
            this.Password = adm.Password;
        }

        public AdministratorLoginDTO()
        {

        }

        public Administrator toEntity() => new Administrator
        {
            Email = this.Email,
            Password = this.Password,

        };

       
    }


}
