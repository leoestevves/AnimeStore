using System.ComponentModel.DataAnnotations;

namespace AnimeStore.API.Dtos;

public record class CreateAnimeDto
(    
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Required][Range(1, 2000)] int NumberEpisodes,
    DateOnly ReleaseDate
);
