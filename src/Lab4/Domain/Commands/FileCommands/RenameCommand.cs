using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;

public class RenameCommand : ICommand
{
    private readonly string _filePath;
    private readonly string _newName;

    public RenameCommand(string filePath, string newName)
    {
        _filePath = filePath;
        _newName = newName;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        return context.FileSystem.RenameFile(_filePath, _newName);
    }
}