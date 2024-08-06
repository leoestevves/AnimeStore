namespace AnimeStore.API.Dtos;

public record class UpdateAnimeDto
(
    string Name,
    string Genre,
    int NumberEpisodes,
    DateOnly ReleaseDate
);