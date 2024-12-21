using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;

public interface IListCommandBuilder : ICommandBuilder
{
    IListCommandBuilder SetDepth(Depth depth);
}