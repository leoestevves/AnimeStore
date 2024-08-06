namespace AnimeStore.API.Dtos;

public record class CreateAnimeDto
(
    string Name,
    string Genre,
    int NumberEpisodes,
    DateOnly ReleaseDate
);
