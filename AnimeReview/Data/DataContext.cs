using AnimeReview.Models;
using Microsoft.EntityFrameworkCore;
namespace AnimeReview.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Anime> Anime { get; set; } 

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Reviewer> Reviewers { get; set; }  

        public DbSet<Country> Countries { get; set; }

        public DbSet<AnimeGenre> AnimeGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeGenre>()
                .HasKey(ag => new { ag.AnimeId, ag.GenreId });
            modelBuilder.Entity<AnimeGenre>()
                .HasOne(a => a.Anime)
                .WithMany(ag => ag.AnimeGenres)
                .HasForeignKey(a => a.AnimeId); 
            modelBuilder.Entity<AnimeGenre>()
                .HasOne(g => g.Genre)
                .WithMany(ag => ag.AnimeGenres)
                .HasForeignKey(g => g.GenreId);
        }
    }
}
