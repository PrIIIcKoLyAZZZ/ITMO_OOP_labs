using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Users;

public interface IUser
{
    public UserID UserId { get; }

    public void GetMessage(IMessage message);

    public void ReadMessage(int messageNumber);

    public IMessage ReturnMessage(int messageNumber);

    public int GetReceivedMessagesCount();
}