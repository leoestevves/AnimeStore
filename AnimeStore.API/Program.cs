using AnimeStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GET_ANIME_ENDPOINT_NAME = "GetAnime";

List<AnimeDto> animes =
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

//Read  GET /animes
app.MapGet("animes", () => animes);

//ReadById  GET /animes/1
app.MapGet("animes/{id}", (int id) => animes.Find(anime => anime.Id == id)).WithName(GET_ANIME_ENDPOINT_NAME);

//Create  POST /animes
app.MapPost("animes", (CreateAnimeDto newAnime) =>
{
    AnimeDto anime = new(
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
app.MapPatch("animes/{id}", (int id, UpdateAnimeDto updatedAnime ) => 
{
    var index = animes.FindIndex(anime => anime.Id == id);
    
    animes[index] = new AnimeDto(
        id,
        updatedAnime.Name,
        updatedAnime.Genre,
        updatedAnime.NumberEpisodes,
        updatedAnime.ReleaseDate
    );

    return Results.NoContent();
});

app.Run();
