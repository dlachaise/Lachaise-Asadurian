using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebApi.Models;
using System.Threading.Tasks;
namespace MSP.BetterCalm.WebApi.Models
{
    public class AdministratorDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AdministratorDTO(Administrator adm)
        {

            this.Id = adm.Id;
            this.Name = adm.Name;
            this.Email = adm.Email;
            this.Password = adm.Password;

        }

        public AdministratorDTO()
        {

        }

        public Administrator toEntity() => new Administrator
        {

            Id = this.Id,
            Name = this.Name,
            Email = this.Email,
            Password = this.Password

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is AdministratorDTO model)
            {
                if (model.Id != null)
                    result = result && this.Id == model.Id;
                if (model.Name != null)
                    result = this.Name.Equals(model.Name);
                if (model.Email != null)
                    result = this.Email.Equals(model.Email);
                if (model.Password != null)
                    result = this.Password.Equals(model.Password);

            }

            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }


}
