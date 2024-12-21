using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Entities;

public interface IEducationalProgram : IEducationalEntities
{
    public Semester FirstSemester { get; }

    public Semester SecondSemester { get; }

    public IEducationalProgramBuilder Direct();

    public EntityEditingResult SetNewFirstSemester(IUser user, Semester newSemester);

    public EntityEditingResult SetNewSecondSemester(IUser user, Semester newSemester);
}