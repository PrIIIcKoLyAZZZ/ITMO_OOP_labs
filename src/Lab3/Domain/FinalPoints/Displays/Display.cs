using Itmo.ObjectOrientedProgramming.Lab3.Domain.DisplayDrivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void PrintMessage(string message)
    {
        _displayDriver.PrintMessage(message);
    }
}