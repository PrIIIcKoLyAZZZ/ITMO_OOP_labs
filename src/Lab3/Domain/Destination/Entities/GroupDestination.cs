using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

public class GroupDestination : IDestination
{
    private readonly IEnumerable<IDestination> _destinations;

    public GroupDestination(IEnumerable<IDestination> destinations)
    {
        _destinations = destinations;
    }

    public void PassTheMessage(IMessage message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.PassTheMessage(message);
        }
    }
}