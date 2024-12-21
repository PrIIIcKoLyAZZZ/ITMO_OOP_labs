using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers;

public class TreeHandler : BaseHandler
{
    private readonly IHandler _responsibilityChain;

    public TreeHandler(IHandler responsibilityChain)
    {
        _responsibilityChain = responsibilityChain;
    }

    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "tree")
            return Next.Handle(commandIterator);

        return _responsibilityChain.Handle(commandIterator.MoveNext());
    }
}