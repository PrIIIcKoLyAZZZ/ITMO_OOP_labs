using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers.ConnectArguments;

public interface IConnectArgumentsHandler
{
    IConnectArgumentsHandler SetNext(IConnectArgumentsHandler connectArgumentsHandler);

    ArgumentHandlingResult Handle(CommandIterator commandIterator, IConnectCommandBuilder connectCommandBuilder);
}