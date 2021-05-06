using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface ISessionLogic
    {
        Session Create(Session session);
        Session Get(Guid id);
        Session GetByToken(string token);
        bool IsValidToken(string token, Administrator admin);
    }
}