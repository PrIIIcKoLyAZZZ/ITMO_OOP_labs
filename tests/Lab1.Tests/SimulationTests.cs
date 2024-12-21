using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.FinalSections;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Railways;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes.Sections.Stations;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;
using Xunit;

namespace Lab1.Tests;

public class SimulationTests
{
    [Fact]
    public static void Test_Force_And_Base_Rail_Simulate_Assert_Success()
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(50)),
                new Rails(new Distance(1)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simResult = route.TryToPassTheRoute(train);

        Assert.True(simResult is PassingResult.Success);
    }

    [Fact]
    public static void Test_Force_And_Base_Rail_Simulate_Assert_Fail()
    {
        var train = new Train(new Mass(3), new Force(500));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(100)),
                new Rails(new Distance(1)),
                new FinalSection(new Speed(1)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Fall);
    }

    [Fact]
    public static void Test_Force_And_Base_Rail_With_One_Station_Simulate_Assert_Success()
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(50)),
                new Rails(new Distance(1)),
                new Station(new Passangers(15), new Speed(100), new Time(1)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Success);
    }

    [Fact]
    public static void Test_Force_Rails_And_One_Station_Simulate_Assert_Fall()
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(50)),
                new Station(new Passangers(15), new Speed(1), new Time(1)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Fall);
    }

    [Fact]
    public static void Test_Force_Rail_With_One_Station_And_Final_Speed_Limit_Simulate_Assert_Fall()
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(50)),
                new Rails(new Distance(1)),
                new Station(new Passangers(15), new Speed(100), new Time(1)),
                new FinalSection(new Speed(1)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Fall);
    }

    [Fact]
    public static void Test_Base_Rail_Simulate_Assert_Fall()
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new Rails(new Distance(1)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Fall);
    }

    [Fact]
    public static void Test_With_Different_rails_And_Stations()
    {
        var train = new Train(new Mass(3), new Force(1000));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(1), new Force(500)),
                new Rails(new Distance(1)),
                new PowerRails(new Distance(1), new Force(-150)),
                new Station(new Passangers(15), new Speed(100), new Time(1)),
                new PowerRails(new Distance(1), new Force(500)),
                new Rails(new Distance(1)),
                new PowerRails(new Distance(1), new Force(-150)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Success);
    }

    [Theory]
    [InlineData(1, 50)]
    public static void Test_With_Force_Rails_With_Y_Force_And_Minus2Y_Force(double x, double y)
    {
        var train = new Train(new Mass(3), new Force(100));
        var route = new Route(
            new List<ISection>()
            {
                new PowerRails(new Distance(x), new Force(y)),
                new PowerRails(new Distance(x), new Force(-2 * y)),
                new FinalSection(new Speed(200)),
            });

        PassingResult simRes = route.TryToPassTheRoute(train);

        Assert.True(simRes is PassingResult.Fall);
    }
}