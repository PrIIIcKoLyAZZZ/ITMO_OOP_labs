namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

public record struct Name
{
    public Name(string name)
    {
        if (name is "")
        {
            throw new ArgumentException("Name field cannot be empty");
        }

        TextField = name;
    }

    public string TextField { get; private set; }
}