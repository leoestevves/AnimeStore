using AnimeStore.API.Data;
using AnimeStore.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("AnimeStore");
builder.Services.AddSqlite<AnimeStoreContext>(connString);

var app = builder.Build();

app.MapAnimesEndpoints();

app.MigrateDb();

app.Run();
