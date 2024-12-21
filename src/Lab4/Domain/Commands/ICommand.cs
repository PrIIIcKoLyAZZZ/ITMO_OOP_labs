using Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands;

public interface ICommand
{
    public ExecutionResult Execute(Context context);
}