using Application.Contexts;
using Application.Services;
using Presentation.Scenarios.AccountScenarios;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class ChoseLoginVariant : IScenario
{
    private readonly AccountService _accountService;
    private readonly UserService _userService;

    public ChoseLoginVariant(AccountService accountService, UserService userService)
    {
        _accountService = accountService;
        _userService = userService;
    }

    public string Name => "Chose login variant";

    public IScenario Run(Context context)
    {
        IEnumerable<IScenario> scenarios = new IScenario[]
        {
            new AccountLogin(_accountService, "account login"),
            new UserLogin(_userService),
            new AccountCreation(_accountService),
        };

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        return scenario;
    }
}