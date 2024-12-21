using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;

public interface IHandler
{
    public IHandler SetNext(IHandler handler);

    public CommandBuildingResult Handle(CommandIterator commandIterator);
}