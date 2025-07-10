using GameStore.Api.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndpointName = "GetGame";

List<GameDTO> games = 
[
    new (1, "Game One", "Action", 29.99m, new DateOnly(2023, 1, 15)),
    new (2, "Game Two", "Adventure", 49.99m, new DateOnly(2023, 2, 20)),
    new (3, "Game Three", "RPG", 39.99m, new DateOnly(2023, 3, 10))
];


//GET /games
app.MapGet("games", () => games);

//GET /games/1

app.MapGet("games/{id}", (int id) =>
{
    var game = games.Find(g => g.ID == id);
    return game is not null ? Results.Ok(game) : Results.NotFound();
}).WithName(GetGameEndpointName);


//POST /games

app.MapPost("games", (CreateGameDTO newGame) =>
{
    GameDTO game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate // or RealiseDate if you intended the spelling
    );

    games.Add(game);

    return Results.CreatedAtRoute(
        GetGameEndpointName,
        new { id = game.ID },
        game
    );
});

app.Run();
