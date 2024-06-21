using System.Runtime.Serialization;

namespace MyShapesLib.Exceptions;

public class InvalidShapeDataException : Exception
{
    private const string DefaultMessage = "All values must be positive!";

    public InvalidShapeDataException() : base(DefaultMessage) {}

    public InvalidShapeDataException(string? message) : base(message) {}

    public InvalidShapeDataException(string? message, Exception? innerException) : base(message, innerException) {}

    protected InvalidShapeDataException(SerializationInfo info, StreamingContext context) : base(info, context) {}
}
