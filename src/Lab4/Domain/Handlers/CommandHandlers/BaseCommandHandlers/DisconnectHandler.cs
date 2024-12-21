using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.BaseCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers;

public class DisconnectHandler : BaseHandler
{
    public override CommandBuildingResult Handle(CommandIterator commandIterator)
    {
        if (commandIterator.GetCurrent() != "disconnect")
            return Next.Handle(commandIterator);

        return new CommandBuildingResult.Success(new DisconnectCommand());
    }
}