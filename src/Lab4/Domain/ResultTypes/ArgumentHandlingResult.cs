namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

public abstract record ArgumentHandlingResult
{
    public sealed record Success() : ArgumentHandlingResult();

    public sealed record Failure() : ArgumentHandlingResult();
}