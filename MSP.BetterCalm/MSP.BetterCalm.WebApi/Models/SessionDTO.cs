using System;
using System.Collections.Generic;
using System.Linq;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.WebApi.Models;
using System.Threading.Tasks;

namespace MSP.BetterCalm.WebApi.Models
{
    public class SessionDTO
    {
        public string Token;
        public Guid Id;
        public DateTime Date;
        public Administrator Administrator;

        public SessionDTO(Session session)
        {

            this.Id = session.Id;
            this.Date = session.Date;
            this.Token = session.Token;
            this.Administrator = session.Administrator;

        }

        public SessionDTO()
        {

        }

        public Session toEntity() => new Session
        {

            Id = this.Id,
            Date = this.Date,
            Token = this.Token,
            Administrator = this.Administrator,

        };


    }
}