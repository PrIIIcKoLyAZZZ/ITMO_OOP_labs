using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;

public class CompositeFilter : IFilter
{
    private readonly IEnumerable<IFilter> _filters;

    public CompositeFilter(IEnumerable<IFilter> filters)
    {
        _filters = filters;
    }

    public bool Check(IMessage message)
    {
        return _filters.All(f => f.Check(message));
    }
}