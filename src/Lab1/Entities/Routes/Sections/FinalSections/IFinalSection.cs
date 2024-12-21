using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.FinalSections;

public interface IFinalSection : ISection
{
    public Speed MaxAllowableSpeed { get; }
}