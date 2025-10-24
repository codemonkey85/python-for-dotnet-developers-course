using Ch7_Db.Data;
using Ch7_Db.Services;

namespace Ch7_Db.Models;

public class GuitarsViewModel(string style)
{
    public string Style { get; } = style;
    public Guitar[] Guitars { get; } = CatalogService.AllGuitars(style);
}
