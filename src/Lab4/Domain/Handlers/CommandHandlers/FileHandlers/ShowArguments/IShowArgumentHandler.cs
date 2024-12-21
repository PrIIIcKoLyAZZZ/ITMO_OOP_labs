using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers.ShowArguments;

public interface IShowArgumentHandler
{
    public IShowArgumentHandler SetNext(IShowArgumentHandler showArgumentHandler);

    public ArgumentHandlingResult Handle(CommandIterator commandIterator, IShowCommandBuilder showCommandBuilder);
}