namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

public record struct EntityName
{
    public EntityName(string textField)
    {
        if (textField is "")
        {
            throw new ArgumentException("Name field cannot be empty");
        }

        TextField = textField;
    }

    public string TextField { get; private set; }
}