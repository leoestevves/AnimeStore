using System.ComponentModel.DataAnnotations;

namespace AnimeStore.API.Dtos;

public record class UpdateAnimeDto
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(50)] string Genre,
    [Required][Range(1, 2000)] int NumberEpisodes,
    DateOnly ReleaseDate
);