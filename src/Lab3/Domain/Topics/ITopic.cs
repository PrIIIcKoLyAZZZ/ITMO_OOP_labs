using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Topics;

public interface ITopic
{
    public Name TopicName { get; }

    public void PassTheMessage(IMessage message);
}