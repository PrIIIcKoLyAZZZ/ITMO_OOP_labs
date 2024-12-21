using Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

public class DisplayDestination : IDestination
{
    private readonly IDisplay _display;

    public DisplayDestination(IDisplay display)
    {
        _display = display;
    }

    public void PassTheMessage(IMessage message)
    {
        _display.PrintMessage(message.ToString() ?? throw new ArgumentNullException(nameof(message)));
    }
}