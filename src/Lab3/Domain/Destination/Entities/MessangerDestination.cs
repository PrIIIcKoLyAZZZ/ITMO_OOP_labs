using Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

public class MessangerDestination : IDestination
{
    private readonly IMessenger _messenger;

    public MessangerDestination(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void PassTheMessage(IMessage message)
    {
        _messenger.PrintMessage(message.ToString() ?? throw new ArgumentNullException(nameof(message)));
    }
}