using FrontEnd.Models;

namespace FrontEnd.Clients;

public class GamesClient()
{
    //public async Task<GameList[]> GetGamesAsync()
    //  => await httpClient.GetFromJsonAsync<GameList[]>("games") ?? [];

    private readonly List<GameList> games = [
    new (){Id = 1, Name = "One", Genre="A Genre", Price = 10.88M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 2, Name = "One-2", Genre="D Genre", Price = 100.98M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 3, Name = "One-3", Genre="C Genre", Price = 10M, ReleaseDate = new DateOnly(1999,4,10)},
    new (){Id = 4, Name = "One-4", Genre="A Genre", Price = 15.88M, ReleaseDate = new DateOnly(1999,4,10)}
      ];

    private readonly Genre[] genres = new GenresClient().GetGenres();
    public GameList[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genre = genres.Single(s => s.Id == int.Parse(game.GenreId));
        var gList = new GameList
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };

        games.Add(gList);
    }

    public GameDetails GetGame(int Id)
    {
        GameList? game = games.Find(s => s.Id == Id);
        ArgumentNullException.ThrowIfNull(game);
        var genre = genres.Single(s => s.Name == game.Genre);

        return new GameDetails
        {
            Name = game.Name,
            Id = game.Id,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };
    }
}
