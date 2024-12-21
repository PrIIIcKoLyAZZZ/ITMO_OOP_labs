using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;

public class EducationalProgramBuilder : IEducationalProgramBuilder
{
    private readonly IUser? _programManager;
    private Guid _programId;
    private Guid _originProgramId;
    private Name _programName;
    private Semester _firstSemester;
    private Semester _secondSemester;

    public EducationalProgramBuilder(IUser? programManager)
    {
        _programManager = programManager;
    }

    public EntityBuildingResult<IEducationalProgram> Build()
    {
        return new EntityBuildingResult<IEducationalProgram>.Success(new EducationalProgram(
            _programId,
            _originProgramId,
            _programManager ?? throw new ArgumentException("Program manager cannot be null"),
            _programName,
            _firstSemester,
            _secondSemester));
    }

    public IEducationalProgramBuilder SetEducationalProgramID(Guid educationalProgramId)
    {
        _programId = educationalProgramId;
        return this;
    }

    public IEducationalProgramBuilder SetEducationalProgramOriginID(Guid educationalProgramOriginId)
    {
        _originProgramId = educationalProgramOriginId;
        return this;
    }

    public IEducationalProgramBuilder SetEducationalProgramName(Name name)
    {
        _programName = name;
        return this;
    }

    public IEducationalProgramBuilder SetEducationalProgramFirstSemester(Semester firstSemester)
    {
        _firstSemester = firstSemester;
        return this;
    }

    public IEducationalProgramBuilder SetEducationalProgramSecondSemester(Semester secondSemester)
    {
        _secondSemester = secondSemester;
        return this;
    }
}