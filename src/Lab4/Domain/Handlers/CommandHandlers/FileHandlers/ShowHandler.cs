using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers.ShowArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;

public class ShowHandler : BaseHandler
{
    private readonly IShowArgumentHandler _showArgumentHandler;
    private readonly IPrinter _printer;

    public ShowHandler(IShowArgumentHandler showArgumentHandler, IPrinter printer)
    {
        _showArgumentHandler = showArgumentHandler;
        _printer = printer;
    }

    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "show")
            return Next.Handle(commandIterator);

        string path = commandIterator.MoveNext().GetCurrent();
        if (string.IsNullOrEmpty(path))
            return new CommandBuildingResult.Failure();

        var showCommandBuilder = new ConsoleShowCommandBuilder(path, _printer);

        commandIterator.MoveNext();
        while (commandIterator.IsAtEnd() is false)
        {
            ArgumentHandlingResult argumentHandlingResult = _showArgumentHandler.Handle(commandIterator, showCommandBuilder);
            if (argumentHandlingResult is ArgumentHandlingResult.Failure)
                return new CommandBuildingResult.Failure();

            commandIterator.MoveNext();
        }

        return showCommandBuilder.Build();
    }
}