using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;

public interface ILabworkBuilder : IEducationalEntitiesBuilder<ILabwork>
{
    public ILabworkBuilder SetName(Name name);

    public ILabworkBuilder SetDiscription(EntityContent discription);

    public ILabworkBuilder SetEvaluationCriteria(EntityContent evaluationCriteria);

    public ILabworkBuilder SetPoints(Points points);

    public ILabworkBuilder SetLabworkID(Guid id);

    public ILabworkBuilder SetLabworkOriginID(Guid originId);
}