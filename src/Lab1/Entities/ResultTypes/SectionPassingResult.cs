using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;

public abstract record SectionPassingResult
{
    public sealed record SectionPassed(Time Time) : SectionPassingResult;

    public sealed record SectionIsNotPassed(Time Time) : SectionPassingResult;
}