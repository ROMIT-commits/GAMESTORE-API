using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record class CreateGameDTO
([Required] string Name,
string Genre,
[Range(1,100000)] decimal Price,
 DateOnly ReleaseDate
 );