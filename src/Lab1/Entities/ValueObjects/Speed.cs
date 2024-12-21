namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Speed
{
    public Speed(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }
}