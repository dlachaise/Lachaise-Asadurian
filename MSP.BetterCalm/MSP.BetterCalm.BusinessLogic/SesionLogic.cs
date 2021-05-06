using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;

namespace MSP.BetterCalm.BusinessLogic
{
    public class SesionLogic
    {

        private IRepository<Session> iSessionR;

        public SesionLogic(IRepository<Session> sessionR)
        {
            this.iSessionR = sessionR;
        }
        public Session Create(Session session)
        {
            iSessionR.Create(session);
            iSessionR.Save();
            return session;
            {
                throw new Exception("The session already exists");
            }
        }

        public Session Get(Guid id)
        {
            Session session = iSessionR.Get(id);
            if (session != null)
            {
                return session;
            }
            else
            {
                throw new Exception("Session does not exist");
            }
        }

        public Session GetByToken(string token)
        {
            Session session = iSessionR.GetAll().First(x => x.Token == token);
            if (session != null)
            {
                return session;
            }
            else
            {
                throw new Exception("Session does not exist");
            }
        }

         public Guid GetAuthorization(string email, string password)
        {
           var extraValues= new Dictionary<string, string>
            {
                { "username", email },
                { "password", password },
            };

            return GetToken();
        }

         private Guid GetToken()
        {
            return Guid.NewGuid();
        }

        //   private bool IsValidToken(string token, Administrator admin)
        // {
        //      Session session = this.GetByToken(token);
        //      var sessions = iSessionR.GetAll().OrderBy(p=> p.Date);
        // }
            

    }
}

