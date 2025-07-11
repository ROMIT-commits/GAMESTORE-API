 GameStore API

A minimal yet scalable ASP.NET Core Web API project for managing a collection of video games. 
Built using .NET 6+, this API demonstrates clean architecture, top-level minimal APIs, DTO usage, and code optimizations.

---

 Features

- ASP.NET Core Web API using **Minimal APIs**
- Clean separation with **DTOs**
- **RESTful Endpoints** (GET, POST, PUT, DELETE)
- **In-memory list** used for mock data
- **Error/Exception Handling** built-in
- Easy to extend for database or authentication support

---

 Project Structure

├── DTOs/ # Data Transfer Objects
├── Endpoints/ # Modular route definitions
├── Program.cs # Main application entry
├── .gitignore # Ignoring user-specific and build files

ENDPOINTS:

| Method | Endpoint      | Description          |
| ------ | ------------- | -------------------- |
| GET    | `/games`      | Get all games        |
| GET    | `/games/{id}` | Get game by ID       |
| POST   | `/games`      | Add a new game       |
| PUT    | `/games/{id}` | Update existing game |
| DELETE | `/games/{id}` | Delete game by ID    |



+> Modular routing via MapGamesEndpoints() in GamesEndpoints.cs

+> Replaced raw request handling with DTOs for clarity

+> Added exception handling (e.g., 404 for not found)

+> Ensured proper usage of route names and constraints

+> Followed C# naming conventions and clean coding practices


Sample DTO:
public record GameDTO(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
