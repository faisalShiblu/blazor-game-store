namespace FrontEnd.Models;

public class GameList
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Genre { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
