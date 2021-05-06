using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Session
    {
        public Administrator Administrator;
        public Guid Id;
        public string Token;

        public DateTime Date;
    }
}