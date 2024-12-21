using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.BaseCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Xunit;

namespace Lab4.Tests;

public class TestCases
{
    [Theory]
    [InlineData("connect folder -m local", typeof(LocalConnectCommand))]
    [InlineData("disconnect", typeof(DisconnectCommand))]
    [InlineData("tree goto folder", typeof(CheckoutCommand))]
    [InlineData("tree list -d 2", typeof(ListCommand))]
    [InlineData("file show file -m console", typeof(ConsoleShowCommand))]
    [InlineData("file move path1 path2", typeof(MoveCommand))]
    [InlineData("file copy path1 path2", typeof(CopyCommand))]
    [InlineData("file delete path", typeof(DeleteCommand))]
    [InlineData("file rename path mewName", typeof(RenameCommand))]

    public static void Try_To_Build_Commads_Assert_Success(string command, Type type)
    {
        var commandParser = new CommandParser();
        IHandler commandHandler = new HandlerFactory(new Config()).CreateHandler();

        bool check = false;
        CommandBuildingResult res;

        CommandIterator iterator = commandParser.Parse(command);
        res = commandHandler.Handle(iterator);

        if (res is CommandBuildingResult.Success result)
        {
            if (result.Command.GetType() == type)
                check = true;
        }

        Assert.True(check);
    }
}