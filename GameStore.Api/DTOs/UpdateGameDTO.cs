namespace GameStore.Api.DTOs;

public record class UpdateGameDTO
(int ID,
string Name,
string Genre,
decimal Price,
 DateOnly ReleaseDate
 );
