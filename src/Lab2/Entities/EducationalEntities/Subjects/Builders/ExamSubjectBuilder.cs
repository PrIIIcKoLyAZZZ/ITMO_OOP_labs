using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;

public class ExamSubjectBuilder : IExamSubjectBuilder
{
    private readonly IUser? _subjectAuthor;
    private Guid _subjectId;
    private Guid _subjectOriginId;
    private Name _subjectName;
    private IReadOnlyCollection<ILabwork>? _subjectLabworksList;
    private IReadOnlyCollection<ILecture>? _subjectLecturesList;
    private Points _maxPointsForSubject;

    public ExamSubjectBuilder(IUser? subjectAuthor)
    {
        _subjectAuthor = subjectAuthor;
    }

    public EntityBuildingResult<ISubject> Build()
    {
        if (_maxPointsForSubject.Value != 100)
        {
            return new EntityBuildingResult<ISubject>.Fall();
        }

        return new EntityBuildingResult<ISubject>.Success(new ExamSubject(
            _subjectId,
            _subjectOriginId,
            _subjectName,
            _subjectAuthor ?? throw new ArgumentException("Subject Author cannot be null"),
            _subjectLabworksList ?? throw new ArgumentException("Labworks list cannot be null"),
            _subjectLecturesList ?? throw new ArgumentException("Lectures list cannot be null"),
            _maxPointsForSubject));
    }

    public IExamSubjectBuilder SetSubjectID(Guid subjectId)
    {
        _subjectId = subjectId;
        return this;
    }

    public IExamSubjectBuilder SetSubjectOriginID(Guid subjectOriginId)
    {
        _subjectOriginId = subjectOriginId;
        return this;
    }

    public IExamSubjectBuilder SetSubjectName(Name subjectName)
    {
        _subjectName = subjectName;
        return this;
    }

    public IExamSubjectBuilder SetLabworksList(IReadOnlyCollection<ILabwork> labworksList)
    {
        _subjectLabworksList = labworksList;
        return this;
    }

    public IExamSubjectBuilder SetLecturesList(IReadOnlyCollection<ILecture> lecturesList)
    {
        _subjectLecturesList = lecturesList;
        return this;
    }

    public IExamSubjectBuilder SetMaxPointsForSubject(Points points)
    {
        _maxPointsForSubject = points;
        return this;
    }
}