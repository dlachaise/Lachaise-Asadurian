using System;
using MSP.BetterCalm.Domain;
namespace MSP.BetterCalm.WebApi.Models
{
    public class AdministratorDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public AdministratorDTO(Administrator adm)
        {

            this.Id = adm.Id;
            this.Name = adm.Name;
            this.Email = adm.Email;
            this.IsActive = adm.IsActive;

        }

        public AdministratorDTO()
        {

        }

        public Administrator toEntity() => new Administrator
        {

            Id = this.Id,
            Name = this.Name,
            Email = this.Email,
            IsActive = this.IsActive

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

            }

            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }


}
