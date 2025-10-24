using Moq;

namespace Ch8_Testing;

public static class TestData
{
    public static ILogger GetMockLogger()
    {
        var mockLog = new Mock<ILogger>();
        return mockLog.Object;
    }

    public static IDb GetMockDb()
    {
        var guitars = TestGuitarData();

        var mockDb = new Mock<IDb>();
        mockDb.Setup(m => m.GetGuitarsFromDb())
            .Returns(guitars);

        return mockDb.Object;
    }

    private static Guitar[] TestGuitarData()
    {
        Guitar[] guitars =
        [
            new Guitar("Jet Black Electric", 599, "/img/guitars/jet-black-electric.jpg", "electric"),
                new Guitar("Weezer Classic", 1499, "/img/guitars/weezer-classic.jpg", "electric"),
                new Guitar("Acoustic Black", 299, "/img/guitars/black-acoustic.jpg", "acoustic"),
                new Guitar("Brush Riffs", 599, "/img/guitars/brushed-black-electric.jpg", "electric"),
                new Guitar("Electric Wood Grain", 399, "/img/guitars/woodgrain-electric.jpg", "electric")
        ];

        return guitars;
    }
}
