using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers.ConnectArguments;

public class ConnectModeHandler : ConnectArgumentHandler
{
    public override ArgumentHandlingResult Handle(CommandIterator commandIterator, IConnectCommandBuilder connectCommandBuilder)
    {
        if (commandIterator.GetCurrent() != "-m")
        {
            if (Next is null)
                return new ArgumentHandlingResult.Failure();
            else
                return Next.Handle(commandIterator, connectCommandBuilder);
        }

        string mode = commandIterator.MoveNext().GetCurrent();
        if (string.IsNullOrEmpty(mode))
            return new ArgumentHandlingResult.Failure();

        connectCommandBuilder.SetMode(mode);
        return new ArgumentHandlingResult.Success();
    }
}