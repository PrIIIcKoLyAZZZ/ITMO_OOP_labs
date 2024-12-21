using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders;

public interface ICommandBuilder
{
    CommandBuildingResult Build();
}