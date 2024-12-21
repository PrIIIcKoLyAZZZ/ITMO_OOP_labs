using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.BaseCommands;

public class LocalConnectCommand : ICommand
{
    private readonly string _path;

    public LocalConnectCommand(string filePath)
    {
        _path = filePath;
    }

    public ExecutionResult Execute(Context context)
    {
        context.FileSystem = new LocalFileSystem();
        context.Path = _path;

        return new ExecutionResult.Success();
    }
}