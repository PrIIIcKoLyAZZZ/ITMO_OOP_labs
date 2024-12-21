using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands.ListCommands;

public class ListCommand : ICommand
{
    private readonly IPrinter _printer;
    private readonly Config _config;
    private Depth _depth;

    public ListCommand(Depth? depth, IPrinter printer, Config config)
    {
        if (depth is null)
            _depth = config.DefaultDepth;
        else
            _depth = (Depth)depth;

        _printer = printer;
        _config = config;
    }

    public ExecutionResult Execute(Context context)
    {
        if (context.FileSystem is null)
            return new ExecutionResult.Failure();

        string path = context.Path;

        var currentDirectory =
            new FileSystemDirectory(
                GetLocalFiles(
                    context, context.FileSystem.MergePaths(context.Path, path), new Depth(0)),
                context.FileSystem.GetDirectoryName(path),
                new Depth(0));

        var directoryVisitor = new ListVisitor(_config, _printer);
        currentDirectory.Accept(directoryVisitor);

        return new ExecutionResult.Success();
    }

    private IList<IVisitorComponent> GetLocalFiles(Context context, string path, Depth depth)
    {
        if (depth.Value > _depth.Value || context.FileSystem is null)
            return [];

        IList<IVisitorComponent> visitorComponents = [];

        IList<string> directories = context.FileSystem.GetDirectories(context.Path);
        IList<string> files = context.FileSystem.GetFiles(context.Path);

        foreach (string name in directories)
        {
            visitorComponents.Add(
                new FileSystemDirectory(
                    GetLocalFiles(context, context.FileSystem.MergePaths(path, name), new Depth(depth.Value + 1)),
                    new Name(name),
                    new Depth(depth.Value + 1)));
        }

        foreach (string name in files)
        {
            visitorComponents.Add(
                new FileSystemFile(new Name(name), new Depth(depth.Value + 1)));
        }

        return visitorComponents;
    }
}