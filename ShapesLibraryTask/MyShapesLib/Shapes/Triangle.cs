using MyShapesLib.Exceptions;

namespace MyShapesLib.Shapes;

public class Triangle : Polygon, IShape
{
    private double _area = -1;

    public Triangle(double[] sides) : base(3, sides) {}

    public double Area
    {
        get
        {
            if (_area < 0)
            {
                var p = Perimeter() / 2;
                _area = Math.Sqrt(p * (p - Sides[0]) * (p - Sides[1]) * (p - Sides[2]));
            }

            return _area;
        }
    }

    public bool IsRight()
    {
        if (!AreSidesValid()) throw new InvalidShapeDataException();

        if (Sides[2] < Sides[1])
        {
            var temp = Sides[2];
            Sides[2] = Sides[1];
            Sides[1] = temp;
        }

        if (Sides[2] < Sides[0])
        {
            var temp = Sides[2];
            Sides[2] = Sides[0];
            Sides[0] = temp;
        }

        return Sides[2] * Sides[2] == Sides[0] * Sides[0] + Sides[1] * Sides[1];
    }
}
