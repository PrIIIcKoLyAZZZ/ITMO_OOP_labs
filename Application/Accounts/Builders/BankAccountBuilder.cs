using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Accounts.Builders;

public class BankAccountBuilder : IAccountBuilder
{
    private Id? _id = null;
    private PinCode? _pinCode = null;
    private Money? _balance = null;

    public AccountBuildingResult Build()
    {
        if (_id is not { } notNullId || _pinCode is not { } notNullPinCode || _balance is not { } notNullBalance)
            return new AccountBuildingResult.Fail();
        return new AccountBuildingResult.Success(new BankAccount(notNullId, notNullPinCode, notNullBalance));
    }

    public IAccountBuilder SetId(Id id)
    {
        _id = id;
        return this;
    }

    public IAccountBuilder SetPinCode(PinCode pinCode)
    {
        _pinCode = pinCode;
        return this;
    }

    public IAccountBuilder SetBalance(Money balance)
    {
        _balance = balance;
        return this;
    }
}