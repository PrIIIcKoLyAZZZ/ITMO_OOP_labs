using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.FinalSections;

public class FinalSection : IFinalSection
{
    public FinalSection(Speed maxAllowableSpeed)
    {
        MaxAllowableSpeed = maxAllowableSpeed;
    }

    public Speed MaxAllowableSpeed { get; private set; }

    public SectionPassingResult TryToGetThroughSection(ITrain train, Time time)
    {
        if (train.Speed.Value > MaxAllowableSpeed.Value)
        {
            return new SectionPassingResult.SectionIsNotPassed(time);
        }

        return new SectionPassingResult.SectionPassed(time);
    }
}