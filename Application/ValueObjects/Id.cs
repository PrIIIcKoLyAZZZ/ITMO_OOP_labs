namespace Application.ValueObjects;

public record struct Id
{
    public Id(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }
}