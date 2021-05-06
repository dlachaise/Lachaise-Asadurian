using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Pathology
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Psychologist> Psychologist { get; set; }

    }
}