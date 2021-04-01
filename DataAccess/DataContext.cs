using Microsoft.EntityFrameworkCore;
using Domain;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Audio> Audios { get; set; }

        public DbSet<Psychologist> Psychologist { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Pathology> Pathology { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Consultation> Consultations { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}