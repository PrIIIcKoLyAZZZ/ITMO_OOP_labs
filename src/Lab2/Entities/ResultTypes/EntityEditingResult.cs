namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;

public abstract record EntityEditingResult()
{
    public sealed record TheEntityHasBeenChanged() : EntityEditingResult;

    public sealed record AccessDenied() : EntityEditingResult;
}