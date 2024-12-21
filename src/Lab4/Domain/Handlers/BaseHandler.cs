using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;

public abstract class BaseHandler : IHandler
{
    protected IHandler Next { get; private set; } = new LastHandler();

    public IHandler SetNext(IHandler handler)
    {
        if (Next is LastHandler)
            Next = handler;
        else
            Next.SetNext(handler);

        return this;
    }

    public abstract CommandBuildingResult Handle(CommandIterator commandIterator);
}