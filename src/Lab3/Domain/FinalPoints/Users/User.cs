using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Users;

public class User : IUser
{
    private readonly ICollection<UserMessage> _messages;

    public User(UserID userId)
    {
        UserId = userId;
        _messages = [];
    }

    public UserID UserId { get; private set; }

    public void GetMessage(IMessage message)
    {
        _messages.Add(new UserMessageBuilder(message).Build());
    }

    public void ReadMessage(int messageNumber)
    {
        if (_messages.ElementAt(messageNumber - 1).Status is ReadOrUnreadStatus.Read)
        {
            throw new Exception("Message is already read");
        }

        if (messageNumber > _messages.Count)
        {
            throw new ArgumentException("Invalid message number");
        }

        _messages.ElementAt(messageNumber - 1).Read();
    }

    public IMessage ReturnMessage(int messageNumber)
    {
        if (messageNumber > _messages.Count)
        {
            throw new ArgumentException("Message number is out of range");
        }

        return _messages.ElementAt(messageNumber - 1);
    }

    public int GetReceivedMessagesCount()
    {
        return _messages.Count;
    }
}