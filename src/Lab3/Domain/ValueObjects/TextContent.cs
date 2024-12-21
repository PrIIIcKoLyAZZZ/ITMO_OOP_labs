namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

public record struct TextContent
{
    public TextContent(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }
}