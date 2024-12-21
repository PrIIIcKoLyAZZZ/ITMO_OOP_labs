namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

public abstract record ExecutionResult
{
    public sealed record Success() : ExecutionResult;

    public sealed record Failure() : ExecutionResult;

    public sealed record FileDoesNotExist() : ExecutionResult;

    public sealed record DirectoryDoesNotExist() : ExecutionResult;

    public sealed record FileHasBeenFound(string FileContent) : ExecutionResult;
}