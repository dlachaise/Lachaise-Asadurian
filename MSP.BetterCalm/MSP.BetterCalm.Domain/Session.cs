using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MSP.BetterCalm.Domain
{
    public class Session
    {


        public Administrator Administrator { get; set; }
        [Key]
        public Guid Token { get; set; }
        public DateTime Date { get; set; }

        public Session()
        {
            Token = Guid.NewGuid();
        }
    }
}