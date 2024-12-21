namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;

public record struct Depth
{
    public Depth(int value)
    {
        if (value < 0)
            throw new ArgumentException("Value cannot be negative.", nameof(value));

        Value = value;
    }

    public int Value { get; private set; }
}