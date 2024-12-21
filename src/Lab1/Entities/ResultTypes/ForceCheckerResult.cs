using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;

public abstract record ForceCheckerResult()
{
    public sealed record ForceLimitIsNotReached(Speed Speed) : ForceCheckerResult;

    public sealed record ReachedForceLimit(Speed Speed) : ForceCheckerResult;
}