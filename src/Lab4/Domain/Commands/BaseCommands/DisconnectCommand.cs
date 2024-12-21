using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.BaseCommands;

public class DisconnectCommand : ICommand
{
    public ExecutionResult Execute(Context context)
    {
        context.FileSystem = null;
        context.Path = string.Empty;

        return new ExecutionResult.Success();
    }
}