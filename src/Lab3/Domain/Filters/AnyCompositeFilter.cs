using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;

public class AnyCompositeFilter : IFilter
{
    private readonly IEnumerable<IFilter> _filters;

    public AnyCompositeFilter(IEnumerable<IFilter> filters)
    {
        _filters = filters;
    }

    public bool Check(IMessage message)
    {
        return _filters.Any(f => f.Check(message));
    }
}