namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Distance
{
    public Distance(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Distance cannot be less then 0");
        }

        Value = value;
    }

    public double Value { get; private set; }
}