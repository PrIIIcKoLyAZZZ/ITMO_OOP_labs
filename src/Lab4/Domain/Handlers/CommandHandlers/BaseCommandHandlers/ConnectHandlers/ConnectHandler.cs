using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers.ConnectArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers;

public class ConnectHandler : BaseHandler
{
    private readonly IConnectArgumentsHandler _connectArgumentsHandler;

    public ConnectHandler(IConnectArgumentsHandler connectArgumentsHandler)
    {
        _connectArgumentsHandler = connectArgumentsHandler;
    }

    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "connect")
            return Next.Handle(commandIterator);

        string path = commandIterator.MoveNext().GetCurrent();
        if (string.IsNullOrEmpty(path))
            return new CommandBuildingResult.Failure();

        var connectCommandBuilder = new LocalConnectCommandBuilder(path);

        commandIterator.MoveNext();
        while (commandIterator.IsAtEnd() is false)
        {
            ArgumentHandlingResult argumentHandlingResult = _connectArgumentsHandler.Handle(commandIterator, connectCommandBuilder);
            if (argumentHandlingResult is ArgumentHandlingResult.Failure)
                return new CommandBuildingResult.Failure();

            commandIterator.MoveNext();
        }

        return connectCommandBuilder.Build();
    }
}