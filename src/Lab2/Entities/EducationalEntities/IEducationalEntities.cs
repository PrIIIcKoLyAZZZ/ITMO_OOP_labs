using Itmo.ObjectOrientedProgramming.Lab2.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.EducationalEntities;

public interface IEducationalEntities
{
    public EntityEditingResult SetNewName(IUser user, Name newName);

    public Guid EntityID { get; }

    public Guid OriginEntityID { get; }

    public IUser EntityAuthor { get; }

    public Name EntityName { get; }
}