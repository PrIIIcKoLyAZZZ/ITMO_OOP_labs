using Application.Contexts;
using Application.Contracts.AccountServices;
using Application.ResultTypes;
using Spectre.Console;

namespace Presentation.Scenarios.AccountScenarios;

public class ShowHistoryScenario : IScenario
{
    private readonly IAccountService _accountService;

    public ShowHistoryScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Show History";

    public IScenario Run(Context context)
    {
        if (context?.Account == null)
        {
            return new ExitScenario();
        }

        GetTransactionResult result = _accountService.ShowHistory(context.Account);

        if (result is GetTransactionResult.Success getTransactionResult)
        {
            var table = new Table();
            table.AddColumn("operation_type");
            table.AddColumn("amount");

            foreach (IList<string> transaction in getTransactionResult.TransactionList)
            {
                table.AddRow(transaction[0], transaction[1]);
            }

            AnsiConsole.Write(table);
        }

        return new StartScenario();
    }
}