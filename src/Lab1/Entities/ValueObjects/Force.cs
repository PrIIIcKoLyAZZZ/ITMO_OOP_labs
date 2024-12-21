namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Force
{
    public Force(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }
}