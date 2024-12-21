using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Abstractions;

public interface IAccountRepository : IRepository<GetAccountResult>
{
    public void UpdateMoney(int id, double money);

    public int Create(PinCode pinCode);
}