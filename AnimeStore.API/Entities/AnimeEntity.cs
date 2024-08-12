namespace AnimeStore.API.Entities;

public class AnimeEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int GenreId { get; set; }
    public GenreEntity? Genre { get; set; }
    public int NumberEpisodes { get; set; }
    public DateOnly ReleaseDate { get; set; }
}
