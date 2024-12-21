using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Builders;

public class UserMessageBuilder : IUserMessageBuilder
{
    private TextContent _messageTitle;
    private TextContent _messageBody;
    private ImportanceLevel _messageImportanceLevel;

    public UserMessageBuilder(IMessage message)
    {
        _messageTitle = message.MessageTitle;
        _messageBody = message.MessageBody;
        _messageImportanceLevel = message.ImportanceLevel;
    }

    public UserMessage Build()
    {
        return new UserMessage(
            _messageTitle,
            _messageBody,
            _messageImportanceLevel);
    }
}