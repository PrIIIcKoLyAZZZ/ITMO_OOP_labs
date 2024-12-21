using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;

public interface ILabwork : IEducationalEntities
{
    public EntityContent LabworkDescription { get; }

    public EntityContent EvaluationCriteria { get; }

    public Points MaxPoints { get; }

    public ILabworkBuilder Direct();

    public EntityEditingResult SetNewDescription(IUser user, EntityContent newDescription);

    public EntityEditingResult SetNewEvaluationCriteria(IUser user, EntityContent newEvaluationCriteria);
}