using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;

public interface ILectureBuilder : IEducationalEntitiesBuilder<ILecture>
{
    public ILectureBuilder SetLectureID(Guid ledtionId);

    public ILectureBuilder SetLectureOriginID(Guid lectionOriginId);

    public ILectureBuilder SetLectureName(Name lectionName);

    public ILectureBuilder SetLectureSummary(EntityContent lectionSummary);

    public ILectureBuilder SetLectureContent(EntityContent lectionContent);

    public ILectureBuilder SetLectureAuthor(IUser lectionAuthor);
}