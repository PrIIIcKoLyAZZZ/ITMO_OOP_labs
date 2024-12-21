using Application.Contexts;
using Application.Contracts.UserServices;
using Application.ResultTypes;
using Spectre.Console;

namespace Presentation.Scenarios.Login;

public class UserLogin : IScenario
{
    private readonly IUserService _userService;

    public UserLogin(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "User login";

    public IScenario Run(Context context)
    {
        string password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter password:")
                .Secret('-'));
        LoginResult loginResult = _userService.Login(password);

        string message = loginResult switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.UnknownPassword => "Unknown password",
            _ => throw new ArgumentException("Invalid login"),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");

        return this;
    }
}