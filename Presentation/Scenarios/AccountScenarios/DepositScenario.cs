using Application.Contexts;
using Application.Contracts.AccountServices;
using Application.ResultTypes;
using Application.ValueObjects;
using Spectre.Console;

namespace Presentation.Scenarios.AccountScenarios;

public class DepositScenario : IScenario
{
    private readonly IAccountService _accountService;

    public DepositScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Deposit";

    public IScenario Run(Context context)
    {
        if (context.Account is null)
        {
            return new ExitScenario();
        }

        double amount = AnsiConsole.Ask<double>("Enter Deposit Amount: ");

        DepositResult result = _accountService.Deposit(context.Account, new Money(amount));
        if (result is DepositResult.Success success)
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