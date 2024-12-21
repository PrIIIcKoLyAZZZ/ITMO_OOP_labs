namespace Application.Configs;

public class Config
{
    public string AdministratorPassword { get; set; } = "88005553535";

    public string ConnectionString { get; set; } =
        "Host=localhost;Port=6432;Username=postgres;Password=postgres;Database=postgres";
}