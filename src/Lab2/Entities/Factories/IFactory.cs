using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories;

public interface IFactory
{
    public IEducationalProgramBuilder CreateEducationalProgramBuilder();

    public ILabworkBuilder CreateLabworkBuilder();

    public ILectureBuilder CreateLectureBuilder();

    public IExamSubjectBuilder CreateSubjectBuilder();
}