using AnimeStore.API.Dtos;

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

    public static WebApplication MapAnimesEndpoints(this WebApplication app) //Metodo de extensao do webapplication
    {
        //Read  GET /animes
        app.MapGet("animes", () => animes);

        //ReadById  GET /animes/1
        app.MapGet("animes/{id}", (int id) => 
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
        app.MapPost("animes", (CreateAnimeDto newAnime) =>
        {
            AnimeDto anime = new
            (
                animes.Count + 1,
                newAnime.Name,
                newAnime.Genre,
                newAnime.NumberEpisodes,
                newAnime.ReleaseDate
            );

            animes.Add(anime); //Adicionando o elemento novo na lista

            return Results.CreatedAtRoute(GET_ANIME_ENDPOINT_NAME, new {id = anime.Id}, anime); //Mostra onde foi criado
        });

        //Update  PATCH /animes/1
        app.MapPatch("animes/{id}", (int id, UpdateAnimeDto updatedAnime) => 
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
        app.MapDelete("animes/{id}", (int id) => 
        {
            animes.RemoveAll(anime => anime.Id == id);

            return Results.NoContent();
        });

        return app;
    }

}
