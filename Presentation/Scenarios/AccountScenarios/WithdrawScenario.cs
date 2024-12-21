using Application.Contexts;
using Application.Contracts.AccountServices;
using Application.ResultTypes;
using Application.ValueObjects;
using Spectre.Console;

namespace Presentation.Scenarios.AccountScenarios;

public class WithdrawScenario : IScenario
{
    private readonly IAccountService _accountService;

    public WithdrawScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Withdraw";

    public IScenario Run(Context context)
    {
        if (context.Account is null)
        {
            return new ExitScenario();
        }

        double amount = AnsiConsole.Ask<double>("Enter Deposit Amount: ");

        WithdrawingResult result = _accountService.Withdraw(context.Account, new Money(amount));
        if (result is WithdrawingResult.Success success)
        {
            AnsiConsole.WriteLine("Success!");
        }
        else
        {
            AnsiConsole.WriteLine("Failed!");
        }

        return new BackStepScenario();
    }
}