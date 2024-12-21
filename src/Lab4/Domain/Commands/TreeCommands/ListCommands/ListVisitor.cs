using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands.ListCommands;

public class ListVisitor : IVisitor
{
    private readonly string _folderSymbol;
    private readonly string _fileSymbol;
    private readonly char _indentSymbol;
    private readonly IPrinter _printer;

    public ListVisitor(Config config, IPrinter printer)
    {
        _folderSymbol = config.FolderSymbol;
        _fileSymbol = config.FileSymbol;
        _indentSymbol = config.IndentSymbol;
        _printer = printer;
    }

    public void Visit(IVisitorComponent component)
    {
        if (component is FileSystemDirectory directory)
            PrintFolder(directory);

        if (component is FileSystemFile file)
            PrintFile(file);
    }

    private void PrintFolder(FileSystemDirectory folder)
    {
        _printer.Print(
            string.Concat(Enumerable.Repeat(_indentSymbol, folder.Depth.Value))
            + _folderSymbol
            + folder.DirectoryName.Value);
    }

    private void PrintFile(FileSystemFile file)
    {
        _printer.Print(
            string.Concat(Enumerable.Repeat(_indentSymbol, file.Depth.Value))
            + _fileSymbol
            + file.FileName.Value);
    }
}