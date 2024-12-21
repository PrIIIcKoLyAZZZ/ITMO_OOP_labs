using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;

public interface IEducationalProgramBuilder : IEducationalEntitiesBuilder<IEducationalProgram>
{
    public IEducationalProgramBuilder SetEducationalProgramID(Guid educationalProgramId);

    public IEducationalProgramBuilder SetEducationalProgramOriginID(Guid educationalProgramOriginId);

    public IEducationalProgramBuilder SetEducationalProgramName(Name name);

    public IEducationalProgramBuilder SetEducationalProgramFirstSemester(Semester firstSemester);

    public IEducationalProgramBuilder SetEducationalProgramSecondSemester(Semester secondSemester);
}