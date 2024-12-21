using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers.ListArguments;

public interface IListArgumentHandler
{
    public IListArgumentHandler SetNext(IListArgumentHandler listArgumentHandler);

    public ArgumentHandlingResult Handle(CommandIterator commandIterator, IListCommandBuilder listCommandBuilder);
}