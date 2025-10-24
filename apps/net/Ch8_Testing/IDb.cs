using System;

namespace Ch8_Testing;

public interface IDb
{
    Guitar[] GetGuitarsFromDb();
}

public class Db : IDb
{
    public Guitar[] GetGuitarsFromDb()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("      --> GETTING GUITARS FROM DB! Should not see in test.");
        Console.ForegroundColor = ConsoleColor.White;

        Guitar[] guitars =
        [
            new("AX Black", 499, "/img/guitars/ax-black.jpg", "electric"),
            new("Jet Black Electric", 599, "/img/guitars/jet-black-electric.jpg", "electric"),
            new("Weezer Classic", 1499, "/img/guitars/weezer-classic.jpg", "electric"),
            new("Acoustic Black", 299, "/img/guitars/black-acoustic.jpg", "acoustic"),
            new("Mellow Yellow", 799, "/img/guitars/mellow-yellow.jpg", "electric"),
            new("White Vibes", 699, "/img/guitars/white-vibes.jpg", "electric"),
            new("Brush Riffs", 599, "/img/guitars/brushed-black-electric.jpg", "electric"),
            new("Nature''s Song", 799, "/img/guitars/natures-song.jpg", "electric"),
            new("Electric Wood Grain", 399, "/img/guitars/woodgrain-electric.jpg", "electric")
        ];

        return guitars;
    }
}
