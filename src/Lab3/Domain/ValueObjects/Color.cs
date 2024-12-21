namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

public record struct Color
{
    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public byte R { get; private set; }

    public byte G { get; private set; }

    public byte B { get; private set; }
}