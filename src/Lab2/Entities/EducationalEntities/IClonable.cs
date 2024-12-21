namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities;

public interface IClonable<T> where T : IClonable<T>
{
    T Clone();
}