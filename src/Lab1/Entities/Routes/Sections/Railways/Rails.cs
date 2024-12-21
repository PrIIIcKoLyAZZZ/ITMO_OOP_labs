using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Railways;

public class Rails : IRails
{
    public Rails(Distance lenghtOfRail)
    {
        LenghtOfRail = lenghtOfRail;
    }

    public Distance LenghtOfRail { get; private set; }

    public SectionPassingResult TryToGetThroughSection(ITrain train, Time time)
    {
        if (train.Speed.Value <= 0)
        {
            return new SectionPassingResult.SectionIsNotPassed(time);
        }

        return new SectionPassingResult.SectionPassed(new Time((LenghtOfRail.Value / train.Speed.Value) + time.Value));
    }
}