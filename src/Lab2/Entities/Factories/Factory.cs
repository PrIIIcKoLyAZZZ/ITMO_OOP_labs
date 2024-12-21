using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.EducationalPrograms.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Labworks.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Lectures.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Factories;

public class Factory : IFactory
{
    public Factory(IUser author)
    {
        Author = author;
    }

    public IEducationalProgramBuilder CreateEducationalProgramBuilder()
    {
        return new EducationalProgramBuilder(Author);
    }

    public ILabworkBuilder CreateLabworkBuilder()
    {
        return new LabworkBuilder(Author);
    }

    public ILectureBuilder CreateLectureBuilder()
    {
        return new LectureBuilder(Author);
    }

    public IExamSubjectBuilder CreateSubjectBuilder()
    {
        return new ExamSubjectBuilder(Author);
    }

    public IUser Author { get; private set; }
}