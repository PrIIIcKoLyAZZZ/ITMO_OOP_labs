using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Factories;

public interface IHandlerFactory
{
    IHandler CreateHandler();
}