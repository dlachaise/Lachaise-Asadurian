using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;
namespace MSP.BetterCalm.WebApi.Models
{
    public class AudioDTO
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }

        public bool IsActive { get; set; }

        public List<Playlist> Playlists { get; set; }
        public List<Category> Categories { get; set; }

        public AudioDTO(Audio audio)
        {

            this.Id = audio.Id;
            this.Name = audio.Name;
            this.Duration = audio.Duration;
            this.CreatorName = audio.CreatorName;
            this.ImageUrl = audio.ImageUrl;
            this.AudioUrl = audio.AudioUrl;
            this.IsActive = audio.IsActive;
            this.Playlists = audio.Playlists;
            this.Categories = audio.Categories;

        }

        public AudioDTO()
        {

        }

        public Audio toEntity() => new Audio
        {

            Id = this.Id,
            Name = this.Name,
            Duration = this.Duration,
            CreatorName = this.CreatorName,
            ImageUrl = this.ImageUrl,
            AudioUrl = this.AudioUrl,
            IsActive = this.IsActive,
            Playlists = this.Playlists,
            Categories = this.Categories,

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is AudioDTO model)
            {

                if (model.Name != null)
                    result = this.Name.Equals(model.Name);
                if (model.Duration != 0)
                    result = this.Duration.Equals(model.Duration);
                if (model.CreatorName != null)
                    result = this.CreatorName.Equals(model.CreatorName);

            }

            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }


}
