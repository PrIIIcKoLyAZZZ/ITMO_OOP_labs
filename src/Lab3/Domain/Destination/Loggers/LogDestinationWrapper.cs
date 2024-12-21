using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Loggers;

public class LogDestinationWrapper : ILogDestinationWrapper
{
    public LogDestinationWrapper(IDestination destination)
    {
        Destination = destination;
    }

    public IDestination Destination { get; private set; }

    public void PassTheMessage(IMessage message)
    {
        Destination.PassTheMessage(message);
        LogPrinter(message);
    }

    public void SetDestination(IDestination destination)
    {
        Destination = destination;
    }

    private void LogPrinter(IMessage message)
    {
        Console.WriteLine($"Logger: message: {message} has been passed");
    }
}