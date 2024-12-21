using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Loggers;

public interface ILogDestinationWrapper : IDestination
{
    public IDestination Destination { get; }

    public void SetDestination(IDestination destination);
}