using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

public class Message : IMessage
{
    public Message(TextContent messageTitle, TextContent messageBody, ImportanceLevel importanceLevel)
    {
        MessageTitle = messageTitle;
        MessageBody = messageBody;
        ImportanceLevel = importanceLevel;
        Status = ReadOrUnreadStatus.Unread;
    }

    public override string ToString()
    {
        return $"{MessageTitle.Value}\n{MessageBody.Value}\n";
    }

    public TextContent MessageTitle { get; private set; }

    public TextContent MessageBody { get; private set; }

    public ImportanceLevel ImportanceLevel { get; private set; }

    public ReadOrUnreadStatus Status { get; private set; }
}