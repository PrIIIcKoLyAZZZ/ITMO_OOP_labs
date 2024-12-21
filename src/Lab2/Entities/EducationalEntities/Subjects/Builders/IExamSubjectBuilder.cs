using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;

public interface IExamSubjectBuilder : IEducationalEntitiesBuilder<ISubject>
{
    public IExamSubjectBuilder SetSubjectID(Guid subjectId);

    public IExamSubjectBuilder SetSubjectOriginID(Guid subjectOriginId);

    public IExamSubjectBuilder SetSubjectName(Name subjectName);

    public IExamSubjectBuilder SetLabworksList(IReadOnlyCollection<ILabwork> labworksList);

    public IExamSubjectBuilder SetLecturesList(IReadOnlyCollection<ILecture> lecturesList);

    public IExamSubjectBuilder SetMaxPointsForSubject(Points points);
}