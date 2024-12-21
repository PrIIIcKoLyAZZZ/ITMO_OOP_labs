namespace Application.ResultTypes;

public abstract record LoginResult()
{
    public sealed record Success() : LoginResult();

    public sealed record UnknownPassword() : LoginResult();

    public sealed record UnknownPinCode() : LoginResult();
}