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
        Genre genre = GetGenreById(game.GenreId);
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
        GameList game = GetGameSummaryById(Id);
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

    public void EditGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);
        GameList existingGame = GetGameSummaryById(game.Id);
        existingGame.Name = game.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = game.Price;
        existingGame.ReleaseDate = game.ReleaseDate;
    }

    public void DeleteGame(int Id)
    {
        GameList game = GetGameSummaryById(Id);
        games.Remove(game);
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(s => s.Id == int.Parse(id));
    }


    private GameList GetGameSummaryById(int Id)
    {
        GameList? game = games.Find(s => s.Id == Id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }
}
