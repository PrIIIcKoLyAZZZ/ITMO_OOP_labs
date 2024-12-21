using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Railways;

public class PowerRails : IRails
{
    public PowerRails(Distance lenghtOfRail, Force force)
    {
        LenghtOfRail = lenghtOfRail;
        Force = force;
    }

    public Distance LenghtOfRail { get; private set; }

    public Force Force { get; private set; }

    public SectionPassingResult TryToGetThroughSection(ITrain train, Time time)
    {
        ForceCheckerResult checkSpeed = train.TryCalculateSpeed(Force, time);

        if (checkSpeed is ForceCheckerResult.ReachedForceLimit)
        {
            return new SectionPassingResult.SectionIsNotPassed(time);
        }

        if (train.Speed.Value <= 0)
        {
            return new SectionPassingResult.SectionIsNotPassed(time);
        }

        return new SectionPassingResult.SectionPassed(new Time((LenghtOfRail.Value / train.Speed.Value) + time.Value));
    }
}