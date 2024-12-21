using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;

public class CreditSubject : ISubject, IClonable<CreditSubject>
{
    public CreditSubject(Guid entityId, Guid originEntityId, IUser entityAuthor, Name entityName, IReadOnlyCollection<ILabwork> labworkList, IReadOnlyCollection<ILecture> lecturesList, Points maxPoints, Points micCreditPoints)
    {
        EntityID = entityId;
        OriginEntityID = originEntityId;
        EntityAuthor = entityAuthor;
        EntityName = entityName;
        LabworkList = labworkList;
        LecturesList = lecturesList;
        MaxPoints = maxPoints;
        MicCreditPoints = micCreditPoints;
    }

    public Guid EntityID { get; private set; }

    public Guid OriginEntityID { get; private set; }

    public IUser EntityAuthor { get; private set; }

    public Name EntityName { get; private set; }

    public IReadOnlyCollection<ILabwork> LabworkList { get; private set; }

    public IReadOnlyCollection<ILecture> LecturesList { get; private set; }

    public Points MaxPoints { get; private set; }

    public Points MicCreditPoints { get; private set; }

    public CreditSubject Clone()
    {
        return new CreditSubject(
            Guid.NewGuid(),
            EntityID,
            EntityAuthor,
            EntityName,
            LabworkList,
            LecturesList,
            MaxPoints,
            MicCreditPoints);
    }

    public ICreditSubjectBuilder Direct()
    {
        ICreditSubjectBuilder builder = new CreditSubjectBuilder(EntityAuthor)
            .SetSubjectID(Guid.NewGuid())
            .SetSubjectOriginID(EntityID)
            .SetSubjectName(EntityName)
            .SetLabworksList(LabworkList)
            .SetLecturesList(LecturesList)
            .SetMaxPointsForSubject(MaxPoints)
            .SetMinCreditPoints(MicCreditPoints);

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

    public EntityEditingResult SetNewMinCreditPoints(IUser user, Points newMinPoints)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        MicCreditPoints = newMinPoints;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }
}