using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;

public class Labwork : ILabwork, IClonable<Labwork>
{
    public Labwork(Name labworkName, EntityContent descriptoin, EntityContent evaluationCriteria, Points maxPoints, IUser entityAuthor, Guid labworkId, Guid labworkOriginEntityId)
    {
        EntityName = labworkName;
        LabworkDescription = descriptoin;
        EvaluationCriteria = evaluationCriteria;
        MaxPoints = maxPoints;
        EntityAuthor = entityAuthor;
        EntityID = labworkId;
        OriginEntityID = labworkOriginEntityId;
    }

    public Name EntityName { get; private set; }

    public EntityContent LabworkDescription { get; private set; }

    public EntityContent EvaluationCriteria { get; private set; }

    public Points MaxPoints { get; private set; }

    public Guid EntityID { get; }

    public Guid OriginEntityID { get; }

    public IUser EntityAuthor { get; private set; }

    public Labwork Clone()
    {
        return new Labwork(
            EntityName,
            LabworkDescription,
            EvaluationCriteria,
            MaxPoints,
            EntityAuthor,
            Guid.NewGuid(),
            EntityID);
    }

    public ILabworkBuilder Direct()
    {
        ILabworkBuilder builder = new LabworkBuilder(EntityAuthor)
            .SetName(EntityName)
            .SetDiscription(LabworkDescription)
            .SetEvaluationCriteria(EvaluationCriteria)
            .SetPoints(MaxPoints)
            .SetLabworkID(Guid.NewGuid())
            .SetLabworkOriginID(EntityID);

        return builder;
    }

    public EntityEditingResult SetNewName(IUser user, Name newName)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        EntityName = newName;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }

    public EntityEditingResult SetNewDescription(IUser user, EntityContent newDescription)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        LabworkDescription = newDescription;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }

    public EntityEditingResult SetNewEvaluationCriteria(IUser user, EntityContent newEvaluationCriteria)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        EvaluationCriteria = newEvaluationCriteria;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }
}