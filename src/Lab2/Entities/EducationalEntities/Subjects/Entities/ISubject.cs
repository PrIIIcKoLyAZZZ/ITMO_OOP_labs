using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;

public interface ISubject : IEducationalEntities
{
    public IReadOnlyCollection<ILabwork> LabworkList { get; }

    public IReadOnlyCollection<ILecture> LecturesList { get; }

    public Points MaxPoints { get; }

    public EntityEditingResult SetNewLabworksList(IUser user, IReadOnlyCollection<ILabwork> labworksList);

    public EntityEditingResult SetNewLecturesList(IUser user, IReadOnlyCollection<ILecture> lecturesList);
}