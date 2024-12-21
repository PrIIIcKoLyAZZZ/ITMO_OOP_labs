using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers.ListArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers;

public class ListHandler : BaseHandler
{
    private readonly IListArgumentHandler _listArgumentHandler;
    private readonly IPrinter _printer;
    private readonly Config _config;

    public ListHandler(IListArgumentHandler listArgumentHandler, IPrinter printer, Config config)
    {
        _listArgumentHandler = listArgumentHandler;
        _printer = printer;
        _config = config;
    }

    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "list")
            return Next.Handle(commandIterator);

        var listCommandBuilder = new ListCommandBuilder(_printer, _config);

        commandIterator.MoveNext();
        while (commandIterator.IsAtEnd() is false)
        {
            ArgumentHandlingResult argumentHandlingResult = _listArgumentHandler.Handle(commandIterator, listCommandBuilder);
            if (argumentHandlingResult is ArgumentHandlingResult.Failure)
                return new CommandBuildingResult.Failure();

            commandIterator.MoveNext();
        }

        return listCommandBuilder.Build();
    }
}