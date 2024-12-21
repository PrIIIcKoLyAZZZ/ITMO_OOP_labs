using Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Infrastructure.Repositories;

public class Repository<T> where T : IEducationalEntities
{
    private readonly ICollection<T> _educationalEntities;

    public Repository()
    {
        _educationalEntities = [];
    }

    public void AddEntity(T entitiy)
    {
        _educationalEntities.Add(entitiy);
    }

    public T FindEntity(Guid id)
    {
        return _educationalEntities.First(e => e.EntityID == id);
    }
}