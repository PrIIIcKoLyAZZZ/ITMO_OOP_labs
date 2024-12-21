namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

public struct Name
{
    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Name field cannot be empty");
        }

        Value = value;
    }

    public string Value { get; private set; }
}