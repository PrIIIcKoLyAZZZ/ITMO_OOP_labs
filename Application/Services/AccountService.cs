using Application.Abstractions;
using Application.Accounts;
using Application.Contexts;
using Application.Contracts.AccountServices;
using Application.ResultTypes;
using Application.ValueObjects;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionsRepository _transactionsRepository;

    public AccountService(IAccountRepository accountRepository, ITransactionsRepository transactionsRepository)
    {
        _accountRepository = accountRepository;
        _transactionsRepository = transactionsRepository;
    }

    public LoginResult Login(string id, string pinCode, Context context)
    {
        if (GetAccountById(new Id(int.Parse(id))) is GetAccountResult.Success success)
        {
            IAccount account = success.Account;

            if (int.Parse(pinCode) == account.AccountPinCode.Value)
            {
                context.Account = account;
                return new LoginResult.Success();
            }
        }

        return new LoginResult.UnknownPinCode();
    }

    public GetTransactionResult GetAccountHistory(Id id)
    {
        return _transactionsRepository.GetById(id.Value);
    }

    public DepositResult Deposit(IAccount account, Money amount)
    {
        SaveChanges(account.AccountId, "Deposit", amount);
        UpdateBalance(account.AccountId, amount);

        return account.Deposit(amount);
    }

    public WithdrawingResult Withdraw(IAccount account, Money amount)
    {
        WithdrawingResult depositResult = account.Withdraw(amount);
        if (depositResult is WithdrawingResult.NotEnoughMoney) return new WithdrawingResult.Fall();

        SaveChanges(account.AccountId, "Withdrawing", amount);
        UpdateBalance(account.AccountId, amount);

        return new WithdrawingResult.Success();
    }

    public GetTransactionResult ShowHistory(IAccount account)
    {
        return _transactionsRepository.GetById(account.AccountId.Value);
    }

    public int CreateAccount(string newPinCode)
    {
        return _accountRepository.Create(new PinCode(int.Parse(newPinCode)));
    }

    private GetAccountResult GetAccountById(Id id)
    {
        return _accountRepository.GetById(id.Value);
    }

    private void SaveChanges(Id accountId, string operationType, Money amount)
    {
        _transactionsRepository.AddTransaction(accountId, operationType, amount);
    }

    private void UpdateBalance(Id accountId, Money amount)
    {
        _accountRepository.UpdateMoney(accountId.Value, amount.Value);
    }
}