using AnimeStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeStore.API.Data;

public class AnimeStoreContext(DbContextOptions<AnimeStoreContext> options ) : DbContext(options)
{
    public DbSet<AnimeEntity> Animes => Set<AnimeEntity>();

    public DbSet<GenreEntity> Genres => Set<GenreEntity>();
}
