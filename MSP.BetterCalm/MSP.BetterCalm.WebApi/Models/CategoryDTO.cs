using System;
using MSP.BetterCalm.Domain;
using System.Collections.Generic;

namespace MSP.BetterCalm.WebApi.Models
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Audio> Audios { get; set; }
        public List<Playlist> Playlists { get; set; }

        public CategoryDTO(Category cat)
        {
            this.Id = cat.Id;
            this.Name = cat.Name;
            this.Audios = cat.Audios;
            this.Playlists = cat.Playlists;

        }
        public CategoryDTO()
        {

        }

        public Category toEntity() => new Category
        {

            Id = this.Id,
            Name = this.Name,
            Audios = this.Audios,
            Playlists = this.Playlists

        };

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is CategoryDTO model)
            {
                if (model.Id != null)
                    result = result && this.Id == model.Id;
                if (model.Name != null)
                    result = this.Name.Equals(model.Name);
                if (model.Audios != null)
                    result = this.Audios.Equals(model.Audios);
                if (model.Playlists != null)
                    result = this.Playlists.Equals(model.Playlists);

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





