using Application.Builder;
using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Accounts.Builders;

public interface IAccountBuilder : IBuilder<AccountBuildingResult>
{
    public IAccountBuilder SetId(Id id);

    public IAccountBuilder SetPinCode(PinCode pinCode);

    public IAccountBuilder SetBalance(Money balance);
}