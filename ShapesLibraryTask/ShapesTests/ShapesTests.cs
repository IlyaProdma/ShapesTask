using MyShapesLib.Exceptions;
using MyShapesLib.Shapes;

namespace ShapesTests;

public class ShapesTests
{
    const double DOUBLE_TOLERANCE = 0.0000001;

    [Test]
    public void SetCircleRadius_NegativeOrZero_MustThrowInvalidShapeDataException()
    {
        var initialRadius = 1;
        var negativeRadius = -1;
        var zeroRadius = 0;
        var circle = new Circle(initialRadius);

        Assert.Throws<InvalidShapeDataException>(() => circle.Radius = negativeRadius);
        Assert.Throws<InvalidShapeDataException>(() => circle.Radius = zeroRadius);
    }

    [Test]
    public void ConstructCircle_NegativeOrZeroRadius_MustThrowInvalidShapeDataException() {
        var negativeRadius = -1;

        Assert.Throws<InvalidShapeDataException>(() => new Circle(negativeRadius));
    }

    [Test]
    public void CircleGetArea_RadiusEqualsOne_AreaMustBeEqualToPi() {
        var initialRadius = 1;

        var circle = new Circle(initialRadius);
        Assert.IsTrue(Math.Abs(circle.Area - Math.PI) < DOUBLE_TOLERANCE);
    }

    [Test]
    public void TriangleConstructor_WrongInputNumberOfSides_MustThrowInvalidOperationException() {
        var inputSides = new[] { 1d, 2 };

        Assert.Throws<InvalidOperationException>(() => new Triangle(inputSides));
    }

    [Test]
    public void TriangleConstructor_InputSidesHasNegativeValues_MustThrowInvalidShapeDataException() {
        var inputSides = new[] { 1d, -1, 2 };

        Assert.Throws<InvalidShapeDataException>(() => new Triangle(inputSides));
    }

    [Test]
    public void TrianglePerimeter_OneSideIsNegative_MustThrowInvalidShapeDataException() {
        var inputSides = new[] { 1d, 1, 1 };
        var triangle = new Triangle(inputSides);

        triangle.Sides[0] = -1;

        Assert.Throws<InvalidShapeDataException>(() => triangle.Perimeter());
    }

    [Test]
    public void TriangleGetArea_OneSideIsNegative_MustThrowInvalidShapeDataException() {
        var inputSides = new[] { 1d, 1, 1 };
        var triangle = new Triangle(inputSides);

        triangle.Sides[0] = -1;

        Assert.Throws<InvalidShapeDataException>(() => { var area = triangle.Area; });
    }

    [Test]
    public void TriangleGetArea_AllSidesValid_MustBeCalculatedRight() {
        var inputSides = new[] { 3d, 4, 5 };
        var triangle = new Triangle(inputSides);
		
		// треугольник с соотношением сторон 3-4-5 называется "Египетским"
		// и является прямоугольным, поэтому его площадь можно посчитать как
		// половину прямоугольника, в данном случае имеющего стороны 3x4:
        // 0.5 * 3 * 4 = 6
        var standardArea = 6.0;
        var triangleCalculatedArea = triangle.Area;

        Assert.IsTrue(Math.Abs(triangleCalculatedArea - standardArea) < DOUBLE_TOLERANCE);
    }

    [Test]
    public void TriangleIsRight_OneSideIsNegative_MustThrowInvalidShapeDataException() {
        var inputSides = new[] { 1d, 1, 1 };
        var triangle = new Triangle(inputSides);

        triangle.Sides[0] = -1;

        Assert.Throws<InvalidShapeDataException>(() => triangle.IsRight());
    }

    [Test]
    public void TriangleIsRight_SidesDoNotFormRightAngle_MustReturnFalse() {
        var inputSides = new[] { 1d, 1, 1 };
        var triangle = new Triangle(inputSides);

        Assert.IsFalse(triangle.IsRight());
    }

    [Test]
    public void TriangleIsRight_SidesFormRightAngle_MustReturnTrue() {
        var inputSides = new[] { 5d, 4, 3 };
        var triangle = new Triangle(inputSides);

        Assert.IsTrue(triangle.IsRight());
    }
}