namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;

public record struct Name
{
    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }

        Value = value;
    }

    public string Value { get; private set; }
}