using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;

public class MoveCommand : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        return context.FileSystem.MoveFile(_sourcePath, _destinationPath);
    }
}