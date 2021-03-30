using System;
using System.Collections.Generic;

namespace Domain
{
    public class Pathology
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<Psychologist> Psychologists {get; set;}
    }
}