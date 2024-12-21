namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ConnectBuilders;

public interface IConnectCommandBuilder : ICommandBuilder
{
    public IConnectCommandBuilder SetPath(string path);

    public IConnectCommandBuilder SetMode(string mode);
}