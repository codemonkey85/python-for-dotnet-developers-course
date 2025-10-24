using Ch6_Web.Data;
using Ch6_Web.Services;

namespace Ch6_Web.Models;

public class GuitarsViewModel(string style)
{
    public string Style { get; } = style;
    public Guitar[] Guitars { get; } = CatalogService.AllGuitars(style);
}
