using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

public abstract record CommandBuildingResult
{
    public sealed record Success(ICommand Command) : CommandBuildingResult;

    public sealed record Failure() : CommandBuildingResult;
}