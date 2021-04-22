using System;
namespace Domain
{
    public class Audio
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string CreatorName { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }

        public bool IsActive { get; set; }



        
        public Audio()
        {
            Id = Guid.NewGuid();
        }
    }
}