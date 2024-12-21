using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;

public abstract record PassingResult
{
    public sealed record Success(Time Time, Distance Distance) : PassingResult;

    public sealed record Fall(Time Time, Distance Distance) : PassingResult;
}