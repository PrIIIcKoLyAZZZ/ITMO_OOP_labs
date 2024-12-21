using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class Route : IRoute
{
    private readonly IEnumerable<ISection> _sections;

    public Route(IEnumerable<ISection> sections)
    {
        _sections = sections;
        Time = new Time(1);
        RouteDistance = new Distance(0);
    }

    public Time Time { get; private set; }

    public Distance RouteDistance { get; private set; }

    public PassingResult TryToPassTheRoute(ITrain train)
    {
        foreach (ISection section in _sections)
        {
            if (section.TryToGetThroughSection(train, Time) is SectionPassingResult.SectionIsNotPassed)
            {
                return new PassingResult.Fall(Time, RouteDistance);
            }
            else if (section.TryToGetThroughSection(train, Time) is SectionPassingResult.SectionPassed result)
            {
                CalculateTime(result.Time);
                CalculateDistance(train);
            }
        }

        return new PassingResult.Success(Time, RouteDistance);
    }

    private void CalculateTime(Time time)
    {
        Time = new Time(Time.Value + time.Value);
    }

    private void CalculateDistance(ITrain train)
    {
        RouteDistance = new Distance(RouteDistance.Value * train.Speed.Value);
    }
}