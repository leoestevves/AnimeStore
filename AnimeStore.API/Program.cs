using AnimeStore.API.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

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

//GET /animes
app.MapGet("animes", () => animes);

//GET /animes/1
app.MapGet("animes/{id}", (int id) => animes.Find(anime => anime.Id == id));



app.Run();
