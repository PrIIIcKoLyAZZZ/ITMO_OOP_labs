using Itmo.ObjectOrientedProgramming.Lab4.Domain.Builders.ShowBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers.ShowArguments;

public class FileModeHandler : ShowArgumentHandler
{
    public override ArgumentHandlingResult Handle(CommandIterator commandIterator, IShowCommandBuilder showCommandBuilder)
    {
        if (commandIterator.GetCurrent() != "-m")
        {
            if (Next is null)
                return new ArgumentHandlingResult.Failure();
            else
                return Next.Handle(commandIterator, showCommandBuilder);
        }

        string mode = commandIterator.MoveNext().GetCurrent();

        if (string.IsNullOrEmpty(mode))
            return new ArgumentHandlingResult.Failure();

        showCommandBuilder.SetMode(mode);
        return new ArgumentHandlingResult.Success();
    }
}