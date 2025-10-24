namespace Ch6_Web.Data;

public class Guitar(string name, float price, string img, string style)
{
    public string Name { get; } = name;
    public float Price { get; } = price;
    public string Img { get; } = img;
    public string Style { get; } = style;
}
