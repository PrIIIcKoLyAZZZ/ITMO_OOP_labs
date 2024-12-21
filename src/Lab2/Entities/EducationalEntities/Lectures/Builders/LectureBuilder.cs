using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;

public class LectureBuilder : ILectureBuilder
{
    private Guid _lectureId;
    private Guid _lectureOriginId;
    private Name _lectureName;
    private IUser? _lectureAuthor;
    private EntityContent _lectureSummary;
    private EntityContent _lectureContent;

    public LectureBuilder(IUser? lectureAuthor)
    {
        _lectureAuthor = lectureAuthor;
    }

    public LectureBuilder()
    {
    }

    public EntityBuildingResult<ILecture> Build()
    {
        return new EntityBuildingResult<ILecture>.Success(new Lecture(
            _lectureId,
            _lectureOriginId,
            _lectureName,
            _lectureSummary,
            _lectureContent,
            _lectureAuthor ?? throw new ArgumentException("Lecture authore cabbot be null")));
    }

    public ILectureBuilder SetLectureID(Guid ledtionId)
    {
        _lectureId = ledtionId;
        return this;
    }

    public ILectureBuilder SetLectureOriginID(Guid lectionOriginId)
    {
        _lectureOriginId = lectionOriginId;
        return this;
    }

    public ILectureBuilder SetLectureName(Name lectionName)
    {
        _lectureName = lectionName;
        return this;
    }

    public ILectureBuilder SetLectureAuthor(IUser lectionAuthor)
    {
        _lectureAuthor = lectionAuthor;
        return this;
    }

    public ILectureBuilder SetLectureSummary(EntityContent lectionSummary)
    {
        _lectureSummary = lectionSummary;
        return this;
    }

    public ILectureBuilder SetLectureContent(EntityContent lectionContent)
    {
        _lectureContent = lectionContent;
        return this;
    }
}