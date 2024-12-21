using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;

public class Lecture : ILecture, IClonable<Lecture>
{
    public Lecture(Guid entityId, Guid originEntityId, Name entityName, EntityContent summary, EntityContent content, IUser entityAuthor)
    {
        EntityID = entityId;
        OriginEntityID = originEntityId;
        EntityName = entityName;
        Summary = summary;
        Content = content;
        EntityAuthor = entityAuthor;
    }

    public Guid EntityID { get; private set; }

    public Guid OriginEntityID { get; private set; }

    public Name EntityName { get; private set; }

    public EntityContent Summary { get; private set; }

    public EntityContent Content { get; private set; }

    public IUser EntityAuthor { get; private set; }

    public Lecture Clone()
    {
        return new Lecture(Guid.NewGuid(), EntityID, EntityName, Summary, Content, EntityAuthor);
    }

    public ILectureBuilder Direct()
    {
        ILectureBuilder builder = new LectureBuilder()
            .SetLectureID(Guid.NewGuid())
            .SetLectureOriginID(EntityID)
            .SetLectureName(EntityName)
            .SetLectureAuthor(EntityAuthor)
            .SetLectureSummary(Summary)
            .SetLectureContent(Content);

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

    public EntityEditingResult SetNewSummary(IUser user, EntityContent newSummary)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        Summary = newSummary;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }

    public EntityEditingResult SetNewContent(IUser user, EntityContent newContent)
    {
        if (user.UserID != EntityAuthor.UserID)
        {
            return new EntityEditingResult.AccessDenied();
        }

        Content = newContent;
        return new EntityEditingResult.TheEntityHasBeenChanged();
    }
}