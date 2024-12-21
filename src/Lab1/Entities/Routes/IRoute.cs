using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public interface IRoute
{
    public Time Time { get; }

    public Distance RouteDistance { get; }

    public PassingResult TryToPassTheRoute(ITrain train);
}