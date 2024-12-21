using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Entities;

public class EducationalProgram : IEducationalProgram, IClonable<EducationalProgram>
{
    public EducationalProgram(Guid entityId, Guid originEntityId, IUser entityAuthor, Name entityName, Semester firstSemester, Semester secondSemester)
    {
        EntityID = entityId;
        OriginEntityID = originEntityId;
        EntityAuthor = entityAuthor;
        EntityName = entityName;
        FirstSemester = firstSemester;
        SecondSemester = secondSemester;
    }

    public Guid EntityID { get; private set; }

    public Guid OriginEntityID { get; private set; }

    public IUser EntityAuthor { get; private set; }

    public Name EntityName { get; private set; }

    public Semester FirstSemester { get; private set; }

    public Semester SecondSemester { get; private set; }

    public EducationalProgram Clone()
    {
        return new EducationalProgram(Guid.NewGuid(), EntityID, EntityAuthor, EntityName, FirstSemester, SecondSemester);
    }

    public IEducationalProgramBuilder Direct()
    {
        IEducationalProgramBuilder builder = new EducationalProgramBuilder(EntityAuthor)
            .SetEducationalProgramID(Guid.NewGuid())
            .SetEducationalProgramOriginID(EntityID)
            .SetEducationalProgramName(EntityName)
            .SetEducationalProgramFirstSemester(FirstSemester)
            .SetEducationalProgramSecondSemester(SecondSemester);

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

    public EntityEditingResult SetNewFirstSemester(IUser user, Semester newSemester)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        FirstSemester = newSemester;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }

    public EntityEditingResult SetNewSecondSemester(IUser user, Semester newSemester)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        SecondSemester = newSemester;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }
}