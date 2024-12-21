using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem.Entities;

public class FileSystemDirectory : IVisitorComponent
{
    private readonly IList<IVisitorComponent> _childEntities;

    public FileSystemDirectory(IList<IVisitorComponent> childEntities, Name directoryName, Depth depth)
    {
        _childEntities = childEntities;
        DirectoryName = directoryName;
        Depth = depth;
    }

    public Name DirectoryName { get; private set; }

    public Depth Depth { get; private set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);

        if (_childEntities.Count > 0)
        {
            foreach (IVisitorComponent childEntity in _childEntities)
            {
                childEntity.Accept(visitor);
            }
        }
    }
}