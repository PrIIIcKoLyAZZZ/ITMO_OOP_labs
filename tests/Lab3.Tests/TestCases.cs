using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.DestinationFilters;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Destination.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class TestCases
{
    [Fact]
    public static void Try_To_Check_Message_Status_Assert_Success()
    {
        var user = new User(new UserID(Guid.NewGuid()));
        var message = new Message(new TextContent("Hello"), new TextContent("Hello, world"), new ImportanceLevel(1));
        bool checkResult = false;

        user.GetMessage(message);

        if (user.ReturnMessage(1).Status is ReadOrUnreadStatus.Unread)
        {
            checkResult = true;
        }

        Assert.True(checkResult);
    }

    [Fact]
    public static void Try_To_Change_Message_Status_Accert_Success()
    {
        var user = new User(new UserID(Guid.NewGuid()));
        var message = new Message(new TextContent("Hello"), new TextContent("Hello, world"), new ImportanceLevel(1));
        bool checkResult = false;
        ReadOrUnreadStatus status1 = ReadOrUnreadStatus.Unread;
        ReadOrUnreadStatus status2 = ReadOrUnreadStatus.Unread;

        user.GetMessage(message);

        status1 = user.ReturnMessage(1).Status;
        user.ReadMessage(1);
        status2 = user.ReturnMessage(1).Status;

        if ((status1 is ReadOrUnreadStatus.Unread) & (status2 is ReadOrUnreadStatus.Read))
        {
            checkResult = true;
        }

        Assert.True(checkResult);
    }

    [Fact]
    public static void Try_To_Read_Reed_Message_Assert_Fall()
    {
        var user = new User(new UserID(Guid.NewGuid()));
        var message = new Message(new TextContent("Hello"), new TextContent("Hello, world"), new ImportanceLevel(1));
        bool checkResult = false;

        user.GetMessage(message);

        user.ReadMessage(1);
        try
        {
            user.ReadMessage(1);
        }
        catch (Exception)
        {
            checkResult = false;
        }

        Assert.True(!checkResult);
    }

    [Fact]
    public static void Try_To_Send_Message_With_Another_Importance_Level_Assert_Fall()
    {
        var mockDestination = new Mock<IDestination>();
        mockDestination
            .Setup(d => d.PassTheMessage(It.IsAny<IMessage>()));

        var importanceFilter = new ImportanceFilter(new ImportanceLevel(5));

        var filters = new List<IFilter> { importanceFilter };
        var destinationFilter = new DestinationFilter(new CompositeFilter(filters), mockDestination.Object);

        var message = new Message(
            new TextContent("Test Title"),
            new TextContent("Test Body"),
            new ImportanceLevel(3));

        destinationFilter.PassTheMessage(message);

        mockDestination.Verify(d => d.PassTheMessage(It.IsAny<IMessage>()), Times.Never);
    }

    [Fact]
    public static void Log_Test_Assert_Success()
    {
        var mockDestination = new Mock<IDestination>();
        mockDestination
            .Setup(d => d.PassTheMessage(It.IsAny<IMessage>()));

        var log = new LogDestinationWrapper(mockDestination.Object);

        var message = new Message(
            new TextContent("Test Title"),
            new TextContent("Test Body"),
            new ImportanceLevel(3));

        log.PassTheMessage(message);

        mockDestination.Verify(d => d.PassTheMessage(It.IsAny<IMessage>()), Times.Once);
    }

    [Fact]
    public static void Try_To_Print_Message_By_Messenger_Assert_True()
    {
        var messenger = new Messenger();

        var mockMessage = new Mock<IMessage>();
        var messageTitle = new TextContent("Title");
        var messageBody = new TextContent("Body");
        mockMessage
            .Setup(m => m.ToString())
            .Returns($"{messageTitle.Value}\n{messageBody.Value}");

        string output = messenger.PrintMessage(mockMessage.Object.ToString() ?? string.Empty);

        Assert.Contains("Messenger: Title\nBody", output, StringComparison.InvariantCulture);
    }

    [Fact]
    public static void Try_To_Pass_Two_Messages_With_One_Importance_Level_With_Filter_Assert_Success()
    {
        var user = new User(new UserID(Guid.NewGuid()));
        var destWithoutFilter = new UserDestination(user);
        var destWithFilter = new UserDestination(user);

        var message = new Message(
            new TextContent("Title"),
            new TextContent("Body"),
            new ImportanceLevel(3));

        var filter = new ImportanceFilter(new ImportanceLevel(5));

        var filters = new List<IFilter> { filter };

        var destFilter = new DestinationFilter(new CompositeFilter(filters), destWithFilter);

        destWithoutFilter.PassTheMessage(message);

        destFilter.PassTheMessage(message);

        Assert.True(user.GetReceivedMessagesCount() == 1);
    }
}