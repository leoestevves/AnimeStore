using AnimeStore.API.Data;
using AnimeStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("AnimeStore");
builder.Services.AddNpgsql<AnimeStoreContext>(connString);

var app = builder.Build();

app.MapAnimesEndpoints();

app.Run();
