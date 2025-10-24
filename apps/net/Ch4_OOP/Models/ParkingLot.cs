using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ch4_OOP.Models;

public class ParkingLot : IEnumerable<string>
{
    private readonly Dictionary<string, Car> spots;

    private ParkingLot(IEnumerable<string> names)
    {
        spots = names.ToDictionary(n => n, Car (name) => null);
    }

    public IEnumerator<string> GetEnumerator() => ((IEnumerable<string>)spots.Keys).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        foreach (var spot in spots.Keys)
        {
            yield return spot;
        }
    }

    public static ParkingLot Create(int spotsPerLevel, int levels)
    {
        var names = new List<string>();
        string[] level_names = ["A", "B", "C", "D", "E", "F", "G"];
        foreach (var ln in level_names.Take(levels))
        {
            for (var n = 0; n < spotsPerLevel; n++)
            {
                names.Add($"{ln}{n + 1}");
            }
        }

        return new ParkingLot(names);
    }

    public string[] TakenSpots() =>
    (
        from spot in spots
        where spot.Value != null
        select $"{spot.Key} has the {spots[spot.Key].ModelName}"
    ).ToArray();

    public void ParkCar(Car car)
    {
        foreach (var kv in spots.Where(kv => kv.Value == null))
        {
            spots[kv.Key] = car;
            break;
        }
    }
}
