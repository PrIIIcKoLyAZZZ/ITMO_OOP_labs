using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Accounts;

public class BankAccount : IAccount
{
    public BankAccount(Id accountId, PinCode accountPinCode, Money accountBalance)
    {
        AccountId = accountId;
        AccountPinCode = accountPinCode;
        AccountBalance = accountBalance;
    }

    public Id AccountId { get; }

    public PinCode AccountPinCode { get; private set; }

    public Money AccountBalance { get; private set; }

    public DepositResult Deposit(Money amount)
    {
        AccountBalance = new Money(AccountBalance.Value + amount.Value);

        return new DepositResult.Success();
    }

    public WithdrawingResult Withdraw(Money amount)
    {
        if (amount.Value > AccountBalance.Value)
            return new WithdrawingResult.NotEnoughMoney();

        return new WithdrawingResult.Success();
    }
}