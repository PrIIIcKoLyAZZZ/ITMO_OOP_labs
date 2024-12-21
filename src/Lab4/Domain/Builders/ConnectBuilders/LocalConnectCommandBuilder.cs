using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.BaseCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;

public class LocalConnectCommandBuilder : IConnectCommandBuilder
{
    private string? _mode;
    private string _path;

    public LocalConnectCommandBuilder(string path)
    {
        _path = path;
    }

    public CommandBuildingResult Build()
    {
        if (string.IsNullOrEmpty(_mode))
            return new CommandBuildingResult.Failure();
        if (_mode is "local")
            return new CommandBuildingResult.Success(new LocalConnectCommand(_path));

        return new CommandBuildingResult.Failure();
    }

    public IConnectCommandBuilder SetPath(string path)
    {
        _path = path;
        return this;
    }

    public IConnectCommandBuilder SetMode(string mode)
    {
        _mode = mode;
        return this;
    }
}