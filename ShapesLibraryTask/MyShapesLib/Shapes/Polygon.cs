using MyShapesLib.Exceptions;

namespace MyShapesLib.Shapes;

public abstract class Polygon
{
    public double[] Sides { get; private set; }

    protected Polygon(uint sidesCount, double[] sides)
    {
        if (sides.Length != sidesCount) throw new InvalidOperationException("Wrong number of sides to initialize this shape.");
        if (sides.Any(side => side <= 0)) throw new InvalidShapeDataException();
        
        Sides = (double[])sides.Clone();
    }

    protected double _perimeter = -1;

    protected bool AreSidesValid() => Sides.All(side => 0 < side);

    public double Perimeter()
    {
        if (!AreSidesValid()) throw new InvalidShapeDataException();

        if (_perimeter < 0) _perimeter = Sides.Sum();

        return _perimeter;
    }
}
