using Application.Accounts;

namespace Application.ResultTypes;

public abstract record AccountBuildingResult
{
    public sealed record Success(IAccount Account) : AccountBuildingResult();

    public sealed record Fail() : AccountBuildingResult();
}