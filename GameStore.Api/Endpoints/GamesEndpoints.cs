using System;
using GameStore.Api.DTOs;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDTO> games =
    [
    new (1, "CS GO", "Action", 29.99m, new DateOnly(2023, 1, 15)),
    new (2, "GTA VI", "Adventure", 49.99m, new DateOnly(2023, 2, 20)),
    new (3, "Efootball", "Sports", 39.99m, new DateOnly(2023, 3, 10))
    ];






    public static RouteGroupBuilder mapGamesEndpoints(this RouteGroupBuilder app)
    {
        var group = app.MapGroup("games");

        //GET /games
        group.MapGet("/", () => games);

        //GET /games/1
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(g => g.ID == id);
            return game is not null ? Results.Ok(game) : Results.NotFound();
        }).WithName(GetGameEndpointName);


        //POST /games

        group.MapPost("/", (CreateGameDTO newGame) =>
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

        //DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {

            var gameToDelete = games.FirstOrDefault(game => game.ID == id);
            System.Console.WriteLine($"Attempting to delete game with ID: {id}");
            if (gameToDelete is null)
            {
                return Results.NotFound();
            }
            games.Remove(gameToDelete);
            return Results.Ok($"Game with ID {id} deleted successfully.");
        });

        //PUT /games

        group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame) =>
        {
            var index = games.FindIndex(g => g.ID == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDTO(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });
        return group;


    }

}
