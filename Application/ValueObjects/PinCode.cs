namespace Application.ValueObjects;

public record struct PinCode
{
    public PinCode(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }
}