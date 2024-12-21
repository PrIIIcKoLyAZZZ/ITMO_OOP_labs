using Application.Accounts;
using Application.Contexts;
using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Contracts.AccountServices;

public interface IAccountService
{
    public LoginResult Login(string id, string pinCode, Context context);

    public DepositResult Deposit(IAccount account, Money amount);

    public WithdrawingResult Withdraw(IAccount account, Money amount);

    public int CreateAccount(string newPinCode);

    public GetTransactionResult ShowHistory(IAccount account);
}