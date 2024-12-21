namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Acceleration
{
    public Acceleration(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }
}