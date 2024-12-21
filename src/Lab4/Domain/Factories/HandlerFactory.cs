using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.BaseCommandHandlers.ConnectHandlers.ConnectArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.FileHandlers.ShowArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers.CommandHandlers.TreeHandlers.ListArguments;
using Itmo.ObjectOrientedProgramming.Lab4.Printers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Factories;

public class HandlerFactory : IHandlerFactory
{
    private readonly Config _config;

    public HandlerFactory(Config config)
    {
        _config = config;
    }

    public IHandler CreateHandler()
    {
        return FileCommand()
            .SetNext(TreeCommand())
            .SetNext(ConnectCommand())
            .SetNext(DisconnectCommand());
    }

    private static DisconnectHandler DisconnectCommand()
    {
        return new DisconnectHandler();
    }

    private static ConnectHandler ConnectCommand()
    {
        var argumentHandler = new ConnectModeHandler();
        return new ConnectHandler(argumentHandler);
    }

    private static FileHandler FileCommand()
    {
        IHandler wordAfterFileHandler =
            new ShowHandler(new FileModeHandler(), new ConsolePrinter())
                .SetNext(new CopyHandler())
                .SetNext(new DeleteHandler())
                .SetNext(new MoveHandler())
                .SetNext(new RenameHandler());

        return new FileHandler(wordAfterFileHandler);
    }

    private TreeHandler TreeCommand()
    {
        IHandler wordAfterTreeHandler =
            new GoToHandler()
                .SetNext(new ListHandler(new ListDepthHandler(), new ConsolePrinter(), _config));

        return new TreeHandler(wordAfterTreeHandler);
    }
}