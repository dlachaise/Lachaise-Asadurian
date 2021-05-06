using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.WebApi.Models
{
    public class PlaylistDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Category> Categories { get; set; }

        public PlaylistDTO(Playlist play)
        {
            this.Id = play.Id;
            this.Name = play.Name;
            this.Audios = play.Audios;
            this.Description = play.Description;
            this.ImageUrl = play.ImageUrl;
            this.Categories = play.Categories;
        }
        public PlaylistDTO()
        {

        }

        public Playlist toEntity() => new Playlist
        {

            Id = this.Id,
            Name = this.Name,
            Audios = this.Audios,
            Description = this.Description,
            ImageUrl = this.ImageUrl,
            Categories = this.Categories,

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is PlaylistDTO model)
            {

                if (model.Name != null)
                    result = this.Name.Equals(model.Name);
                if (model.Audios != null)
                    result = this.Audios.Equals(model.Audios);
                if (model.Description != null)
                    result = this.Description.Equals(model.Description);
                if (model.Categories != null)
                    result = this.Categories.Equals(model.Categories);

            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}





