using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;

public class Train : ITrain
{
    public Train(Mass mass, Force maxAllowableForce)
    {
        Mass = mass;
        Speed = new Speed(0.0);
        MaxAllowableForce = maxAllowableForce;
    }

    public Speed Speed { get; private set; }

    public Mass Mass { get; private set; }

    public Force MaxAllowableForce { get; private set; }

    public ForceCheckerResult TryCalculateSpeed(Force force, Time time)
    {
        if (MaxAllowableForce.Value < force.Value)
        {
            return new ForceCheckerResult.ReachedForceLimit(Speed);
        }

        Speed = new Speed(Speed.Value + (CountAcceleration(force).Value * time.Value));

        return new ForceCheckerResult.ForceLimitIsNotReached(Speed);
    }

    private Acceleration CountAcceleration(Force force)
    {
        return new Acceleration(force.Value / Mass.Value);
    }
}