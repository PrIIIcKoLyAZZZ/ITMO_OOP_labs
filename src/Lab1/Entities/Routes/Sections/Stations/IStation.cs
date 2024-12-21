using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Stations;

public interface IStation : ISection
{
    public Time TimeToBoardOnePassanger { get; }

    public Passangers AmountOfPassangers { get; }

    public Speed MaxAllowableSpeed { get; }
}