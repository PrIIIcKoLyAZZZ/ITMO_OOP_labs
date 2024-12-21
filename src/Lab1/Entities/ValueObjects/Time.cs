namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

public class Time
{
    public Time(double value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Time cannnot be 0 or less");
        }

        Value = value;
    }

    public double Value { get; private set; }
}