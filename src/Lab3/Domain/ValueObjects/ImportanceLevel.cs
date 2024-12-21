namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

public record struct ImportanceLevel
{
    public ImportanceLevel(ushort value)
    {
        if (value <= 10)
        {
            Value = value;
        }
        else
        {
            throw new ArgumentException("The importance level must be a number from 1 to 10.");
        }
    }

    public ushort Value { get; private set; }
}