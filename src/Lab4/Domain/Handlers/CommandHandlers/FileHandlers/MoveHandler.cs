using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class MoveHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "move")
            return Next.Handle(commandIterator);

        string sourcePath = commandIterator.MoveNext().GetCurrent();
        string destinationPath = commandIterator.MoveNext().GetCurrent();

        if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            return new CommandBuildingResult.Failure();

        return new CommandBuildingResult.Success(new MoveCommand(sourcePath, destinationPath));
    }
}