using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers.ConnectArguments;

public abstract class ConnectArgumentHandler : IConnectArgumentsHandler
{
    protected IConnectArgumentsHandler? Next { get; set; }

    public IConnectArgumentsHandler SetNext(IConnectArgumentsHandler connectArgumentsHandler)
    {
        if (Next is null)
            Next = connectArgumentsHandler;
        else
            Next.SetNext(connectArgumentsHandler);

        return this;
    }

    public abstract ArgumentHandlingResult Handle(CommandIterator commandIterator, IConnectCommandBuilder connectCommandBuilder);
}