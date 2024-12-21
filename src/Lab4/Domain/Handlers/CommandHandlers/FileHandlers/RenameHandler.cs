using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class RenameHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "rename")
            return Next.Handle(commandIterator);

        string filePath = commandIterator.MoveNext().GetCurrent();
        string newName = commandIterator.MoveNext().GetCurrent();

        if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(newName))
            return new CommandBuildingResult.Failure();

        return new CommandBuildingResult.Success(new RenameCommand(filePath, newName));
    }
}