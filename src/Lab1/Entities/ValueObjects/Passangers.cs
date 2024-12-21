namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public record struct Passangers
{
    public Passangers(uint value)
    {
        Value = value;
    }

    public uint Value { get; private set; }
}