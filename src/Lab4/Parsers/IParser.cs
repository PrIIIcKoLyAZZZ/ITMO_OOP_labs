namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface IParser<T>
{
    public T Parse(string source);
}