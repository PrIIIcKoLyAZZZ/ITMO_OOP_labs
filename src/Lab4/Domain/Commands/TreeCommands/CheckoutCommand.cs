using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands;

public class CheckoutCommand : ICommand
{
    private readonly string _path;

    public CheckoutCommand(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        context.Path = _path;

        return new ExecutionResult.Success();
    }
}