using Application.ResultTypes;

namespace Application.Contracts.UserServices;

public interface IUserService
{
    public LoginResult Login(string password);
}