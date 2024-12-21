using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;

public class LabworkBuilder : ILabworkBuilder
{
    private readonly IUser? _labworkAuthor;
    private Name _labworkName;
    private EntityContent _labworkDiscription;
    private EntityContent _evaluationCriteria;
    private Points _labworkPoints;
    private Guid _labworkID;
    private Guid _labworkOriginId;

    public LabworkBuilder(IUser? labworkAuthor)
    {
        _labworkAuthor = labworkAuthor;
    }

    public EntityBuildingResult<ILabwork> Build()
    {
        return new EntityBuildingResult<ILabwork>.Success(new Labwork(
            _labworkName,
            _labworkDiscription,
            _evaluationCriteria,
            _labworkPoints,
            _labworkAuthor ?? throw new ArgumentException("Labwork author cannot be null"),
            _labworkID,
            _labworkOriginId));
    }

    public ILabworkBuilder SetName(Name name)
    {
        _labworkName = name;
        return this;
    }

    public ILabworkBuilder SetDiscription(EntityContent discription)
    {
        _labworkDiscription = discription;
        return this;
    }

    public ILabworkBuilder SetEvaluationCriteria(EntityContent evaluationCriteria)
    {
        _evaluationCriteria = evaluationCriteria;
        return this;
    }

    public ILabworkBuilder SetPoints(Points points)
    {
        _labworkPoints = points;
        return this;
    }

    public ILabworkBuilder SetLabworkID(Guid id)
    {
        _labworkID = id;
        return this;
    }

    public ILabworkBuilder SetLabworkOriginID(Guid originId)
    {
        _labworkOriginId = originId;
        return this;
    }
}