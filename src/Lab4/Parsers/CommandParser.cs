namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandParser : IParser<CommandIterator>
{
    public CommandIterator Parse(string source)
    {
        return new CommandIterator(source.Split());
    }
}