namespace Application.ResultTypes;

public abstract record WithdrawingResult
{
    public sealed record Success() : WithdrawingResult();

    public sealed record NotEnoughMoney() : WithdrawingResult();

    public sealed record Fall() : WithdrawingResult();
}