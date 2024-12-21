using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class CopyHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "copy")
            return Next.Handle(commandIterator);

        string sourceFilePath = commandIterator.MoveNext().GetCurrent();
        string destinationFilePath = commandIterator.MoveNext().GetCurrent();

        return new CommandBuildingResult.Success(new CopyCommand(sourceFilePath, destinationFilePath));
    }
}