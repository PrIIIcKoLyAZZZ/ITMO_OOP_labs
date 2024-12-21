using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Topics;

public class Topic : ITopic
{
    private readonly ICollection<IDestination> _destinations;

    public Topic(Name topicName)
    {
        _destinations = [];
        TopicName = topicName;
    }

    public Name TopicName { get; }

    public void PassTheMessage(IMessage message)
    {
        foreach (IDestination destination in _destinations)
        {
            destination.PassTheMessage(message);
        }
    }
}