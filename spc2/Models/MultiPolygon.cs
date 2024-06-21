using System.Collections.Immutable;

namespace spc2.Models;

public class MultiPolygon : IComparable<MultiPolygon>
{
    private static readonly ImmutableDictionary<string, int> sortingOrder = ImmutableDictionary.CreateRange(new Dictionary<string, int>()
    {
        { "TSTM", 5 },
        { "MRGL", 4 },
        { "SLGT", 3 },
        { "ENH", 2 },
        { "MDT", 1 },
        { "HIGH", 0 }
    });

    public List<Polygon> Polygons { get; set; }
    
    public string Name { get; set; }

    public int CompareTo(MultiPolygon? other)
    {
        return sortingOrder[Name].CompareTo(sortingOrder[other.Name]);
    }
}
