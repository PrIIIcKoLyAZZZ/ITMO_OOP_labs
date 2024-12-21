using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;

public class CopyCommand : ICommand
{
    private readonly string _sourceFilePath;
    private readonly string _destinationFilePath;

    public CopyCommand(string sourceFilePath, string destinationFilePath)
    {
        _sourceFilePath = sourceFilePath;
        _destinationFilePath = destinationFilePath;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        return context.FileSystem.CopyFile(_sourceFilePath, _destinationFilePath);
    }
}