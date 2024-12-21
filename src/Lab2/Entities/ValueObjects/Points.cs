namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

public record struct Points
{
    public Points(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Points cannot be less then 0");
        }

        Value = value;
    }

    public int Value { get; private set; }
}