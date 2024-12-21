using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;

public class DeleteCommand : ICommand
{
    private readonly string _filePath;

    public DeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        return context.FileSystem.DeleteFile(_filePath);
    }
}