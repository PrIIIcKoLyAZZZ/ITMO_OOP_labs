using Color = Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects.Color;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public ConsoleDisplayDriver(Color color)
    {
        Color = color;
    }

    public Color Color { get; private set; }

    public void PrintMessage(string message)
    {
        ClearDisplay();
        Console.WriteLine(Modify(message));
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    private string Modify(string message)
    {
        return Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(message);
    }
}