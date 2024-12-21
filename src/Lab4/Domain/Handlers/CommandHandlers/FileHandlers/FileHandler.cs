using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class FileHandler : BaseHandler
{
    private readonly IHandler _responsibilityChain;

    public FileHandler(IHandler responsibilityChain)
    {
        _responsibilityChain = responsibilityChain;
    }

    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "file")
            return Next.Handle(commandIterator);

        return _responsibilityChain.Handle(commandIterator.MoveNext());
    }
}