using FrontEnd.Models;

namespace FrontEnd.Clients;

public class GamesClient()
{
    //public async Task<GameList[]> GetGamesAsync()
    //  => await httpClient.GetFromJsonAsync<GameList[]>("games") ?? [];

    private readonly List<GameList> games = [
    new (){Id = 1, Name = "One", Genre="Action", Price = 10.88M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 2, Name = "One-2", Genre="Action", Price = 100.98M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 3, Name = "One-3", Genre="Action", Price = 10M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 4, Name = "One-4", Genre="Action", Price = 15.88M, ReleaseDate = new DateOnly(1999,4,10)}
      ];

    public GameList[] GetGames() => [.. games];
}
