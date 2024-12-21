namespace Application.ResultTypes;

public abstract record DepositResult
{
    public sealed record Success() : DepositResult;

    public sealed record Fall() : DepositResult;
}