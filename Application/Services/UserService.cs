using Application.Configs;
using Application.Contracts.UserServices;
using Application.ResultTypes;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly Config _config;

    public UserService(Config config)
    {
        _config = config;
    }

    public LoginResult Login(string password)
    {
        if (password != _config.AdministratorPassword)
            return new LoginResult.UnknownPassword();

        return new LoginResult.Success();
    }
}