using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;

public interface IShowCommandBuilder : ICommandBuilder
{
    IShowCommandBuilder SetPath(string path);

    IShowCommandBuilder SetMode(string mode);

    IShowCommandBuilder SetPrinter(IPrinter printer);
}