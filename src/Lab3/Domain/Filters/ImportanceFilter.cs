using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;

public class ImportanceFilter : IFilter
{
    private readonly ImportanceLevel _importanceLevel;

    public ImportanceFilter(ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
    }

    public bool Check(IMessage message)
    {
        return message.ImportanceLevel == _importanceLevel;
    }
}