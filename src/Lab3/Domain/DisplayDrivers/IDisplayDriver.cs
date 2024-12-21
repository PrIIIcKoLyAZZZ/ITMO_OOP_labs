using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.DisplayDrivers;

public interface IDisplayDriver
{
    public Color Color { get; }

    public void PrintMessage(string message);

    public void ClearDisplay();

    public void SetColor(Color color);
}