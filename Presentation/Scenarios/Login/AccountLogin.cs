using Application.Contexts;
using Application.Contracts.AccountServices;
using Application.ResultTypes;
using Presentation.Scenarios.AccountScenarios;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class AccountLogin : IScenario
{
    private readonly IAccountService _accountService;

    public AccountLogin(IAccountService accountService, string name)
    {
        _accountService = accountService;
    }

    public string Name => "Account login";

    public IScenario Run(Context context)
    {
        string id = AnsiConsole.Ask<string>("Enter account id: ");
        string pinCode = AnsiConsole.Ask<string>("Enter pin code: ");

        LoginResult result = _accountService.Login(id, pinCode, context);

        string message = result switch
        {
            LoginResult.UnknownPinCode => "Invalid password or id",
            LoginResult.Success => "Login succeeded",
            _ => "Invalid password or id",
        };

        AnsiConsole.MarkupLine($"\n{message}");

        return result switch
        {
            LoginResult.UnknownPinCode => this,
            LoginResult.Success => new ChooseAccountActions(_accountService),
            _ => new BackStepScenario(),
        };
    }
}