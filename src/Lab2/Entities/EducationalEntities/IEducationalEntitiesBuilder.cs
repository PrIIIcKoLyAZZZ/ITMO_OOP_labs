using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities;

public interface IEducationalEntitiesBuilder<T> where T : IEducationalEntities
{
    EntityBuildingResult<T> Build();
}