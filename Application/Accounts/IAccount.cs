using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Accounts;

public interface IAccount
{
    public Id AccountId { get; }

    public PinCode AccountPinCode { get; }

    public Money AccountBalance { get; }

    public DepositResult Deposit(Money amount);

    public WithdrawingResult Withdraw(Money amount);
}