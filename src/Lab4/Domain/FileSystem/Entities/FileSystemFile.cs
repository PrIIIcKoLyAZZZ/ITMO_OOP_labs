using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem.Entities;

public class FileSystemFile : IVisitorComponent
{
    public FileSystemFile(Name fileName, Depth depth)
    {
        FileName = fileName;
        Depth = depth;
    }

    public Name FileName { get; private set; }

    public Depth Depth { get; private set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}