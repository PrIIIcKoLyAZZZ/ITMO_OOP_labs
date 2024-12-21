namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;

public abstract record EntityBuildingResult<T>
{
    public sealed record Success(T Entity) : EntityBuildingResult<T>;

    public sealed record Fall() : EntityBuildingResult<T>;
}