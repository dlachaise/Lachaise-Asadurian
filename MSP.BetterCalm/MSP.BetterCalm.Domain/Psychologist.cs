using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSP.BetterCalm.Domain
{
    public class Psychologist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MeetingType { get; set; } //1 formato presencial - 2 formato virtual
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Pathology> Pathologies { get; set; }

        [NotMapped]
        public SortedList<DateTime, int> MeetingList { get; set; }

        public DateTime StartDate { get; set; }

        public int Tariff{get;set;} //500 -750 - 1000 -2000
       

      
        public Psychologist Update(Psychologist entity)
        {
            if (entity.Name != null)
                Name = entity.Name;
            if (entity.MeetingType != 0)
                MeetingType = entity.MeetingType;
            if (entity.Address != null)
                Address = entity.Address;
            if (entity.Pathologies != null)
                Pathologies = entity.Pathologies;
            IsActive = entity.IsActive;
            return this;
        }


        public override bool Equals(Object obj)
        {
            var result = false;

            if (obj is Psychologist psychologist)
            {
                result = this.Id == psychologist.Id && this.Address.Equals(psychologist.Address);
            }

            return result;
        }
    }
}

