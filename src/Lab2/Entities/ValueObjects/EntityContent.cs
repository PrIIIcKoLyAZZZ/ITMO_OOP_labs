namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

public record struct EntityContent
{
    public EntityContent(string textField)
    {
        if (textField is "")
        {
            throw new ArgumentException("Content cannot be empty");
        }

        TextField = textField;
    }

    public string TextField { get; private set; }
}