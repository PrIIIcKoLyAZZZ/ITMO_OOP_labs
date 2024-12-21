using Application.Accounts;

namespace Application.ResultTypes;

public abstract record GetAccountResult()
{
    public sealed record Success(IAccount Account) : GetAccountResult();

    public sealed record AccountNotFound(Exception Exception) : GetAccountResult();
}