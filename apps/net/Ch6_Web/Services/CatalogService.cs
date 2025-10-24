using System.Linq;
using Ch6_Web.Data;

namespace Ch6_Web.Services;

public static class CatalogService
{
    public static Guitar[] AllGuitars(string style = null)
    {
        Guitar[] guitars =
        [
            new("AX Black", 499, "/img/guitars/ax-black.jpg", "electric"),
            new("Acoustic Black", 299, "/img/guitars/black-acoustic.jpg", "acoustic"),
            new("Weezer Classic", 1499, "/img/guitars/weezer-classic.jpg", "electric"),
            new("Jet Black Electric", 599, "/img/guitars/jet-black-electric.jpg", "electric"),
            new("Mellow Yellow", 799, "/img/guitars/mellow-yellow.jpg", "electric"),
            new("White Vibes", 699, "/img/guitars/white-vibes.jpg", "electric"),
            new("Brush Riffs", 599, "/img/guitars/brushed-black-electric.jpg", "electric"),
            new("Nature''s Song", 799, "/img/guitars/natures-song.jpg", "electric"),
            new("Electric Wood Grain", 399, "/img/guitars/woodgrain-electric.jpg", "electric")
        ];

        if (style is null or "all")
        {
            return guitars;
        }

        return (
            from g in guitars
            where g.Style == style
            select g
        ).ToArray();
    }
}
