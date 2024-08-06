namespace AnimeStore.API.Dtos;

public record class AnimeDto(
    int Id,
    string Name,
    string Genre,
    int NumberEpisodes,
    DateOnly ReleaseDate
);
