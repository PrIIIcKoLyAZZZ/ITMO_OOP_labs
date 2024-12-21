using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers.ListArguments;

public abstract class ListArgumentHandler : IListArgumentHandler
{
    protected IListArgumentHandler? Next { get; set; }

    public IListArgumentHandler SetNext(IListArgumentHandler listArgumentHandler)
    {
        if (Next is null)
            Next = listArgumentHandler;
        else
            Next.SetNext(listArgumentHandler);

        return this;
    }

    public abstract ArgumentHandlingResult Handle(CommandIterator commandIterator, IListCommandBuilder listCommandBuilder);
}