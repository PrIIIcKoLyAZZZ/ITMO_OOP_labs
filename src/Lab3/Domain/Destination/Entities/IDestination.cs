using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

public interface IDestination
{
    public void PassTheMessage(IMessage message);
}