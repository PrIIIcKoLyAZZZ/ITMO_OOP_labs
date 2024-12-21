using Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

public class UserDestination : IDestination
{
    private readonly IUser _user;

    public UserDestination(IUser user)
    {
        _user = user;
    }

    public void PassTheMessage(IMessage message)
    {
        _user.GetMessage(message);
    }
}