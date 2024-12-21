using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;

public class ExamSubject : ISubject, IClonable<ExamSubject>
{
    public ExamSubject(Guid entityId, Guid originEntityId, Name subjectName, IUser entityAuthor, IReadOnlyCollection<ILabwork> labworkList, IReadOnlyCollection<ILecture> lecturesList, Points maxPointsForSubject)
    {
        EntityID = entityId;
        OriginEntityID = originEntityId;
        EntityName = subjectName;
        EntityAuthor = entityAuthor;
        LabworkList = labworkList;
        LecturesList = lecturesList;
        MaxPoints = maxPointsForSubject;
    }

    public Guid EntityID { get; private set; }

    public Guid OriginEntityID { get; private set; }

    public IUser EntityAuthor { get; private set; }

    public Name EntityName { get; private set; }

    public IReadOnlyCollection<ILabwork> LabworkList { get; private set; }

    public IReadOnlyCollection<ILecture> LecturesList { get; private set; }

    public Points MaxPoints { get; private set; }

    public ExamSubject Clone()
    {
        return new ExamSubject(
            Guid.NewGuid(),
            EntityID,
            EntityName,
            EntityAuthor,
            LabworkList,
            LecturesList,
            MaxPoints);
    }

    public IExamSubjectBuilder Direct()
    {
        IExamSubjectBuilder builder = new ExamSubjectBuilder(EntityAuthor)
            .SetSubjectID(Guid.NewGuid())
            .SetSubjectOriginID(EntityID)
            .SetSubjectName(EntityName)
            .SetLabworksList(LabworkList)
            .SetLecturesList(LecturesList)
            .SetMaxPointsForSubject(MaxPoints);

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

    public EntityEditingResult SetNewLabworksList(IUser user, IReadOnlyCollection<ILabwork> labworksList)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        LabworkList = labworksList;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }

    public EntityEditingResult SetNewLecturesList(IUser user, IReadOnlyCollection<ILecture> lecturesList)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        LecturesList = lecturesList;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }
}