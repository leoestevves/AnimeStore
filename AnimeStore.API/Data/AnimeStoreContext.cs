using AnimeStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeStore.API.Data;

public class AnimeStoreContext(DbContextOptions<AnimeStoreContext> options ) : DbContext(options)
{
    public DbSet<AnimeEntity> Animes => Set<AnimeEntity>();
    public DbSet<GenreEntity> Genres => Set<GenreEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GenreEntity>().HasData
        (
            new {Id = 1, Name = "Fantasy"},
            new {Id = 2, Name = "Drama"},
            new {Id = 3, Name = "Romance"},
            new {Id = 4, Name = "Comedy"},
            new {Id = 5, Name = "Action"}
        );
    }
}
