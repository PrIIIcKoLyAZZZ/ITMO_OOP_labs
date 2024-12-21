using Application.Contexts;
using Application.Contracts.AccountServices;
using Spectre.Console;

namespace Presentation.Scenarios.AccountScenarios;

public class ChooseAccountActions : IScenario
{
    private readonly IAccountService _accountService;

    public ChooseAccountActions(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Account interactions";

    public IScenario Run(Context context)
    {
        var scenarios = new List<IScenario>()
        {
            new DepositScenario(_accountService),
            new WithdrawScenario(_accountService),
            new ShowHistoryScenario(_accountService),
            new ExitScenario(),
        };

        while (true)
        {
            SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
                .Title("Select action")
                .AddChoices(scenarios)
                .UseConverter(x => x.Name);

            IScenario scenario = AnsiConsole.Prompt(selector);

            if (scenario.Run(context) is ExitScenario)
            {
                break;
            }
        }

        return new StartScenario();
    }
}