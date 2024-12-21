using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers.ShowArguments;

public abstract class ShowArgumentHandler : IShowArgumentHandler
{
    protected IShowArgumentHandler? Next { get; set; }

    public IShowArgumentHandler SetNext(IShowArgumentHandler showArgumentHandler)
    {
        if (Next is null)
        {
            Next = showArgumentHandler;
        }
        else
        {
            Next.SetNext(showArgumentHandler);
        }

        return this;
    }

    public abstract ArgumentHandlingResult Handle(CommandIterator commandIterator, IShowCommandBuilder showCommandBuilder);
}