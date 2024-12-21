namespace Application.ValueObjects;

public record struct Money
{
    public Money(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }
}