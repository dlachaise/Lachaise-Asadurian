using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.BusinessLogic.Interface
{
    public interface ISessionLogic
    {
        bool IsValidToken(string token);

        Guid? CreateToken(string email, string password);

    }
}