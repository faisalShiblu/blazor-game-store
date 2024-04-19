using FrontEnd.Models;

namespace FrontEnd.Clients;

public class GenresClient
{
    private readonly Genre[] genres = [
        new (){Id = 1, Name="A Genre"},
        new (){Id = 2, Name="B Genre"},
        new (){Id = 3, Name="C Genre"},
        new (){Id = 4, Name="D Genre"},
        ];

    public Genre[] GetGenres() => genres;
}
