using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;

public interface ILecture : IEducationalEntities
{
    public EntityContent Summary { get; }

    public EntityContent Content { get; }

    public ILectureBuilder Direct();

    public EntityEditingResult SetNewSummary(IUser user, EntityContent newSummary);

    public EntityEditingResult SetNewContent(IUser user, EntityContent newContent);
}