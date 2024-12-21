using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;

public class LastHandler : IHandler
{
    public IHandler SetNext(IHandler handler)
    {
        return this;
    }

    public CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        return new CommandBuildingResult.Failure();
    }
}