using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ListBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers.ListArguments;

public class ListDepthHandler : ListArgumentHandler
{
    public override ArgumentHandlingResult Handle(CommandIterator commandIterator, IListCommandBuilder listCommandBuilder)
    {
        if (commandIterator.GetCurrent() != "-d")
        {
            if (Next is null)
                return new ArgumentHandlingResult.Failure();
            else
                return Next.Handle(commandIterator, listCommandBuilder);
        }

        string depth = commandIterator.MoveNext().GetCurrent();

        if (int.TryParse(depth, out int depthValue))
        {
            listCommandBuilder.SetDepth(new Depth(depthValue));
            return new ArgumentHandlingResult.Success();
        }

        return new ArgumentHandlingResult.Failure();
    }
}