using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

public class User : IUser
{
    public User(Guid userId, Name username)
    {
        UserID = userId;
        Username = username;
    }

    public Guid UserID { get; }

    public Name Username { get; }
}