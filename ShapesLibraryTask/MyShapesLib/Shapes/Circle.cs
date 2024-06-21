using MyShapesLib.Exceptions;

namespace MyShapesLib.Shapes;

public class Circle : IShape
{
    private double _radius = -1;

    public Circle(double radius) {
        if (radius <= 0) throw new InvalidShapeDataException();

        Radius = radius;
    }

    public double Radius {
        get => _radius;
        set {
            if (value <= 0) throw new InvalidShapeDataException();

            _radius = value;
        }
    }

    public double Area
    {
        get {
            return Math.PI * Radius * Radius;
        }
    }
}