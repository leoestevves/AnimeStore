using AnimeStore.API.Data;
using AnimeStore.API.Dtos;
using AnimeStore.API.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AnimeStore.API.Endpoints;

public static class AnimesEndpoints
{
    const string GET_ANIME_ENDPOINT_NAME = "GetAnime";

    private static readonly List<AnimeDto> animes =
    [
        new(
            1,
            "Solo Leveling",
            "Fantasy",
            13,
            new DateOnly(2024, 01, 07)
        ),
        new(
            2,
            "Sousou no Frieren",
            "Fantasy",
            28,
            new DateOnly(2023, 09, 29)
        ),
        new(
            3,
            "The Apothecary Diaries",
            "Drama",
            24,
            new DateOnly(2023, 10, 22)
        )
    ];

    public static RouteGroupBuilder MapAnimesEndpoints(this WebApplication app) //Metodo de extensao do webapplication
    {                                                                           //Quando mudei para group, mudei de WebApplication para RouteGroupBuilder
        var group = app.MapGroup("animes")
                       .WithParameterValidation(); //Ativando as validacoes dos contratos (DTOs)

        //Read  GET /animes
        group.MapGet("/", () => animes);

        //ReadById  GET /animes/1
        group.MapGet("/{id}", (int id) => 
        {
            var anime = animes.Find(anime => anime.Id == id);

            if (anime == null)
            {
                return Results.NotFound();
            } 
            else 
            {
                return Results.Ok(anime);
            }
        })
        .WithName(GET_ANIME_ENDPOINT_NAME);

        //Create  POST /animes
        group.MapPost("/", (CreateAnimeDto newAnime, AnimeStoreContext dbContext) =>
        {
            AnimeEntity anime = new()
            {
                Name = newAnime.Name,
                Genre = dbContext.Genres.Find(newAnime.GenreId),
                GenreId = newAnime.GenreId,
                NumberEpisodes = newAnime.NumberEpisodes,
                ReleaseDate = newAnime.ReleaseDate
            };          

            AnimeDto animeDto = new
            (
                anime.Id,
                anime.Name,
                anime.Genre!.Name,
                anime.NumberEpisodes,
                anime.ReleaseDate
            );

            dbContext.Animes.Add(anime); //Adicionando o elemento novo no banco
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(GET_ANIME_ENDPOINT_NAME, new {id = anime.Id}, animeDto); //Mostra onde foi criado
        });

        //Update  PATCH /animes/1
        group.MapPatch("/{id}", (int id, UpdateAnimeDto updatedAnime) => 
        {    
            var index = animes.FindIndex(anime => anime.Id == id); 

            //Quando nao acha o FindIndex retorna um -1, por isso utilizo if index == -1 para tratar o erro
            if (index == -1)
            {
                return Results.NotFound();
            } 
            
            animes[index] = new AnimeDto
            (
                id,
                updatedAnime.Name,
                updatedAnime.Genre,
                updatedAnime.NumberEpisodes,
                updatedAnime.ReleaseDate
            );

            return Results.NoContent();
        });

        //Delete  DELETE /animes/1
        group.MapDelete("/{id}", (int id) => 
        {
            animes.RemoveAll(anime => anime.Id == id);

            return Results.NoContent();
        });

        return group;
    }

}
