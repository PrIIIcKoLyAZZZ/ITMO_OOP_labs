namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Mass
{
    public Mass(double value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Mass cannot be equal 0 or less");
        }

        Value = value;
    }

    public double Value { get; private set; }
}