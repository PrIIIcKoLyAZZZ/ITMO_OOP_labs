using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;

public interface IFilter
{
    public bool Check(IMessage message);
}