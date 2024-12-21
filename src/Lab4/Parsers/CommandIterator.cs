namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandIterator
{
    private readonly IReadOnlyCollection<string> _arguments;
    private int _counter;

    public CommandIterator(IReadOnlyCollection<string> arguments)
    {
        _arguments = arguments;
        _counter = 0;
    }

    public CommandIterator MoveNext()
    {
        _counter++;
        return this;
    }

    public CommandIterator MovePrevious()
    {
       _counter--;
       return this;
    }

    public string GetCurrent()
    {
        return _arguments.ElementAt(_counter);
    }

    public bool IsAtEnd()
    {
        return (_counter + 1) > _arguments.Count;
    }
}