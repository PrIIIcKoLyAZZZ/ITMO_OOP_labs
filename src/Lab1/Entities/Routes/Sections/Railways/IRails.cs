using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Railways;

public interface IRails : ISection
{
    public Distance LenghtOfRail { get; }
}