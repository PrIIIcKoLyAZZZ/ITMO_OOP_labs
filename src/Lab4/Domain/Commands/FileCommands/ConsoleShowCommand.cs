using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;

public class ConsoleShowCommand : ICommand
{
    private readonly IPrinter _printer;
    private string _path;

    public ConsoleShowCommand(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        _path += context.Path;

        if (context.FileSystem.ShowFile(_path) is ExecutionResult.FileHasBeenFound fileContent)
            _printer.Print(fileContent.FileContent);

        return new ExecutionResult.Success();
    }
}