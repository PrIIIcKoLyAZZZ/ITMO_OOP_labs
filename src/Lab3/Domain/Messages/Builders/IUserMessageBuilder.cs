using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Builders;

public interface IUserMessageBuilder
{
    public UserMessage Build();
}