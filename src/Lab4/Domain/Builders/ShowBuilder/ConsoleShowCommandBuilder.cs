using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;

public class ConsoleShowCommandBuilder : IShowCommandBuilder
{
    private string _path;
    private string? _mode;
    private IPrinter _printer;

    public ConsoleShowCommandBuilder(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public CommandBuildingResult Build()
    {
        if (string.IsNullOrEmpty(_mode))
            return new CommandBuildingResult.Failure();

        if (_mode is "console")
            return new CommandBuildingResult.Success(new ConsoleShowCommand(_path, _printer));

        return new CommandBuildingResult.Failure();
    }

    public IShowCommandBuilder SetPath(string path)
    {
        _path = path;
        return this;
    }

    public IShowCommandBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }

    public IShowCommandBuilder SetPrinter(IPrinter printer)
    {
        _printer = printer;
        return this;
    }
}