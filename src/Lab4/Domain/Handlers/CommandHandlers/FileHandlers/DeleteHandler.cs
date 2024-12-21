using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class DeleteHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "delete")
            return Next.Handle(commandIterator);

        string path = commandIterator.MoveNext().GetCurrent();

        if (string.IsNullOrEmpty(path))
            return new CommandBuildingResult.Failure();

        return new CommandBuildingResult.Success(new DeleteCommand(path));
    }
}