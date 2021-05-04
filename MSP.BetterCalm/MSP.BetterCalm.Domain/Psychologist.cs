using System;
using System.Collections.Generic;

namespace MSP.BetterCalm.Domain
{
    public class Psychologist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MeetingType { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Pathology> Pathologies { get; set; }
        public SortedList<DateTime, int> MeetingList { get; set; }

        public DateTime StartDate { get; set; }


   
        public Psychologist Update(Psychologist entity)
        {
            if (entity.Name != null)
                Name = entity.Name;
            if (entity.MeetingType != null)
                MeetingType = entity.MeetingType;
            if (entity.Address != null)
                Address = entity.Address;
            if (entity.Pathologies != null)
                Pathologies = entity.Pathologies;
            IsActive = entity.IsActive;
            return this;
        }
    }
}

