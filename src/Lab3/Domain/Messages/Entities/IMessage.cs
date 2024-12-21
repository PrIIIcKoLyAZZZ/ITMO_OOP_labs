using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

public interface IMessage
{
    public TextContent MessageTitle { get; }

    public TextContent MessageBody { get; }

    public ImportanceLevel ImportanceLevel { get; }

    public ReadOrUnreadStatus Status { get; }
}