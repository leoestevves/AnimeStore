using AnimeStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapAnimesEndpoints();

app.Run();
