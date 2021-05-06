using System;
using System.Collections.Generic;
using MSP.BetterCalm.Domain;
using MSP.BetterCalm.DataAccess;
using MSP.BetterCalm.BusinessLogic.Interface;
using MSP.BetterCalm.DataAccess.Interface;
using System.Linq;

namespace MSP.BetterCalm.BusinessLogic
{
    public class SessionLogic : ISessionLogic
    {

        private IRepository<Session> iSessionR;

        private IRepository<Administrator> iAdminR;

        private static IDictionary<string, Guid?> TokenRepository = null;

        public SessionLogic(IRepository<Session> sessionR, IRepository<Administrator> adminRepo)
        {
            this.iSessionR = sessionR;
            this.iAdminR = adminRepo;
        }

        public bool IsValidToken(string token)
        {
            Guid tokenGuid = Guid.Parse(token);
            Session sessionFound = iSessionR.Get(tokenGuid);
            if (sessionFound != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Guid? CreateToken(string adminEmail, string password)
        {
            var admins = iAdminR.GetAll();
            var admin = admins.FirstOrDefault(x => x.Email == adminEmail && x.Password == password);
            if (admin == null)
            {
                return null;
            }
            var token = Guid.NewGuid();
            Session newSession = new Session
            {
                Token = token,
                Administrator = admin,
                Date = DateTime.Now
            };
            iSessionR.Create(newSession);
            return token;
        }

    }

}

