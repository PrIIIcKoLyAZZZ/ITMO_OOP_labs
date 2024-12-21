using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Stations;

public class Station : IStation
{
    public Station(Passangers passangerers, Speed maxAllowableSpeed, Time timeToBoardOnePassanger)
    {
        AmountOfPassangers = passangerers;
        MaxAllowableSpeed = maxAllowableSpeed;
        TimeToBoardOnePassanger = timeToBoardOnePassanger;
    }

    public Time TimeToBoardOnePassanger { get; private set; }

    public Passangers AmountOfPassangers { get; private set; }

    public Speed MaxAllowableSpeed { get; private set; }

    public SectionPassingResult TryToGetThroughSection(ITrain train, Time time)
    {
        if (train.Speed.Value > MaxAllowableSpeed.Value)
        {
            return new SectionPassingResult.SectionIsNotPassed(time);
        }

        return new SectionPassingResult.SectionPassed(new Time(CountBoardingTime().Value + time.Value));
    }

    private Time CountBoardingTime()
    {
        return new Time(TimeToBoardOnePassanger.Value * AmountOfPassangers.Value);
    }
}