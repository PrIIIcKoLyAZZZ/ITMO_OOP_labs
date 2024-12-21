using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

public interface IUser
{
    public Guid UserID { get; }

    public Name Username { get; }
}