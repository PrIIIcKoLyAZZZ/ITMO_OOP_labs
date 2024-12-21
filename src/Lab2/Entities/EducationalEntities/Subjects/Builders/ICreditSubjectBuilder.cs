using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;

public interface ICreditSubjectBuilder : IEducationalEntitiesBuilder<ISubject>
{
    public CreditSubjectBuilder SetSubjectID(Guid subjectId);

    public CreditSubjectBuilder SetSubjectOriginID(Guid subjectOriginId);

    public CreditSubjectBuilder SetSubjectName(Name subjectName);

    public CreditSubjectBuilder SetLabworksList(IReadOnlyCollection<ILabwork> labworksList);

    public CreditSubjectBuilder SetLecturesList(IReadOnlyCollection<ILecture> lecturesList);

    public CreditSubjectBuilder SetMaxPointsForSubject(Points points);

    public CreditSubjectBuilder SetMinCreditPoints(Points points);
}