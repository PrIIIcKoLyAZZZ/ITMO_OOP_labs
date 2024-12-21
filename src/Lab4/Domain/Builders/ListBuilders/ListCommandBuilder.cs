using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;

public class ListCommandBuilder : IListCommandBuilder
{
    private readonly IPrinter _printer;
    private readonly Config _config;
    private Depth? _depth;

    public ListCommandBuilder(IPrinter printer, Config config)
    {
        _printer = printer;
        _config = config;
    }

    public CommandBuildingResult Build()
    {
        return new CommandBuildingResult.Success(new ListCommand(_depth, _printer, _config));
    }

    public IListCommandBuilder SetDepth(Depth depth)
    {
        _depth = depth;
        return this;
    }
}