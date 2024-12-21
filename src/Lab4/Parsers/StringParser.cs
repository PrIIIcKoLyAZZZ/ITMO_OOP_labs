namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class StringParser : IParser<ICollection<string>>
{
    public ICollection<string> Parse(string source)
    {
        return source.Split();
    }
}