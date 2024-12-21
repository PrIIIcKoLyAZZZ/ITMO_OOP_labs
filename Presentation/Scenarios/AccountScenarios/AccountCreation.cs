using Application.Contexts;
using Application.Services;
using Spectre.Console;

namespace Presentation.Scenarios.AccountScenarios;

public class AccountCreation : IScenario
{
    private readonly AccountService _accountService;

    public AccountCreation(AccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Create Account";

    public IScenario Run(Context context)
    {
        string newAccountPin = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password:")
                .Secret());

        AnsiConsole.WriteLine($"Your id: {_accountService.CreateAccount(newAccountPin)}");

        Thread.Sleep(3000);

        return new StartScenario();
    }
}