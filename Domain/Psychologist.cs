using System;
using System.Collections.Generic;

namespace Domain
{
    public class Psychologist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MeetingType { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public List<Pathology> Pathologies {get; set;}
    }
}