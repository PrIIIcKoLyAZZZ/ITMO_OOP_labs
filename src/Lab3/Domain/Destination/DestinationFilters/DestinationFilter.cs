using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.DestinationFilters;

public class DestinationFilter : IDestination
{
    private readonly IFilter _compositeFilter;
    private readonly IDestination _destination;

    public DestinationFilter(IFilter compositeFilter, IDestination destination)
    {
        _compositeFilter = compositeFilter;
        _destination = destination;
    }

    public void PassTheMessage(IMessage message)
    {
        if (_compositeFilter.Check(message))
        {
            _destination.PassTheMessage(message);
        }
    }
}