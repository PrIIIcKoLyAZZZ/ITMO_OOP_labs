using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers;

public class GoToHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "goto")
            return Next.Handle(commandIterator);

        string path = commandIterator.MoveNext().GetCurrent();
        if (string.IsNullOrEmpty(path))
            return new CommandBuildingResult.Failure();

        return new CommandBuildingResult.Success(new CheckoutCommand(path));
    }
}