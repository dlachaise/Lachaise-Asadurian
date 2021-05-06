using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.WebApi.Models
{
    public class PathologyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public PathologyDTO(Pathology cat)
        {
            this.Id = cat.Id;
            this.Name = cat.Name;

        }
        public PathologyDTO()
        {

        }

        public Pathology toEntity() => new Pathology
        {

            Id = this.Id,
            Name = this.Name,

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is PathologyDTO model)
            {
                if (model.Name != null)
                    result = this.Name.Equals(model.Name);

            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}





