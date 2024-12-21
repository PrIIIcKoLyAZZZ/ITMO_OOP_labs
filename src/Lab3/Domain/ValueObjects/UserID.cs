namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

public record struct UserID
{
    public UserID(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; private set; }
}