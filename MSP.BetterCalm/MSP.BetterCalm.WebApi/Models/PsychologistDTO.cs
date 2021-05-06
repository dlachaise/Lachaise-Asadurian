using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.WebApi.Models
{
    public class PsychologistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int MeetingType { get; set; } //1 formato presencial - 2 formato virtual
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Pathology> Pathologies { get; set; }
        public DateTime StartDate { get; set; }


        public PsychologistDTO(Psychologist psycho)
        {

            this.Id = psycho.Id;
            this.Name = psycho.Name;
            this.MeetingType = psycho.MeetingType;
            this.IsActive = psycho.IsActive;
            this.Address = psycho.Address;
            this.Pathologies = psycho.Pathologies;
            this.StartDate = psycho.StartDate;

        }

        public PsychologistDTO()
        {

        }

        public Psychologist toEntity() => new Psychologist
        {

            Id = this.Id,
            Name = this.Name,
            MeetingType = this.MeetingType,
            IsActive = this.IsActive,
            Address = this.Address,
            Pathologies = this.Pathologies,
            StartDate = this.StartDate,

        };


    }
}