

namespace Models;

public class Polygon
{
    private List<Point> _points;

    public Polygon(List<Point> points)
    {
        _points = points;
    }

    public bool PointInPolygon(Point point)
    {
        bool odd = false;
        //# For each edge (In this case for each point of the polygon and the previous one)

        var size = _points.Count;
        int i = 0;
        var j = size - 1;

        while (i < size - 1)
        {
            i = i + 1;
            // # If a line from the point into infinity crosses this edge
            // # One point needs to be above, one below our y coordinate
            // # ...and the edge doesn't cross our Y corrdinate before our x coordinate (but between our x coordinate and infinity)

            if (((_points[i].Y > point.Y) != (_points[j].Y > point.Y)) &&
                (point.X < ((_points[j].X - _points[i].X) * (point.Y - _points[i].Y) / (_points[j].Y - _points[i].Y)) + _points[i].X))
            {
                odd = !odd;
            }
            j = i;
        }

        //# If the number of crossings was odd, the point is in the polygon
        return odd;
    }
}