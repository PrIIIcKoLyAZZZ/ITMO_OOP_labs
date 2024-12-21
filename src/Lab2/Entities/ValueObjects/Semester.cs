using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities.Subjects.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

public record struct Semester
{
    public Semester(IReadOnlyCollection<ISubject> listOfSubjects)
    {
        if (listOfSubjects.Count == 0)
        {
            throw new ArgumentException("Subjects List cannot be empty");
        }

        ListOfSubjects = listOfSubjects;
    }

    public IReadOnlyCollection<ISubject> ListOfSubjects { get; private set; }
}