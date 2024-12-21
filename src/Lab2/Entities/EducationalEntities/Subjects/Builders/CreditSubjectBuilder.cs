using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;

public class CreditSubjectBuilder : ICreditSubjectBuilder
{
    private readonly IUser? _subjectAuthor;
    private Guid _subjectId;
    private Guid _subjectOriginId;
    private Name _subjectName;
    private IReadOnlyCollection<ILabwork>? _subjectLabworksList;
    private IReadOnlyCollection<ILecture>? _subjectLecturesList;
    private Points _maxPointsForSubject;
    private Points _minCreditPoints;

    public CreditSubjectBuilder(IUser? subjectAuthor)
    {
        _subjectAuthor = subjectAuthor;
    }

    public EntityBuildingResult<ISubject> Build()
    {
        if (_maxPointsForSubject.Value != 100)
        {
            return new EntityBuildingResult<ISubject>.Fall();
        }

        return new EntityBuildingResult<ISubject>.Success(new CreditSubject(
            _subjectId,
            _subjectOriginId,
            _subjectAuthor ?? throw new ArgumentException("Subject Author cannot be null"),
            _subjectName,
            _subjectLabworksList ?? throw new ArgumentException("Labworks list cannot be null"),
            _subjectLecturesList ?? throw new ArgumentException("Lectures list cannot be null"),
            _maxPointsForSubject,
            _minCreditPoints));
    }

    public CreditSubjectBuilder SetSubjectID(Guid subjectId)
    {
        _subjectId = subjectId;
        return this;
    }

    public CreditSubjectBuilder SetSubjectOriginID(Guid subjectOriginId)
    {
        _subjectOriginId = subjectOriginId;
        return this;
    }

    public CreditSubjectBuilder SetSubjectName(Name subjectName)
    {
        _subjectName = subjectName;
        return this;
    }

    public CreditSubjectBuilder SetLabworksList(IReadOnlyCollection<ILabwork> labworksList)
    {
        _subjectLabworksList = labworksList;
        return this;
    }

    public CreditSubjectBuilder SetLecturesList(IReadOnlyCollection<ILecture> lecturesList)
    {
        _subjectLecturesList = lecturesList;
        return this;
    }

    public CreditSubjectBuilder SetMaxPointsForSubject(Points points)
    {
        _maxPointsForSubject = points;
        return this;
    }

    public CreditSubjectBuilder SetMinCreditPoints(Points points)
    {
        _minCreditPoints = points;
        return this;
    }
}