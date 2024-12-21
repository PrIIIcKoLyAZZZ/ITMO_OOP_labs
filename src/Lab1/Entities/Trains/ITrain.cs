using Itmo.ObjectOrientedProgramming.Lab1.Entities.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Trains;

public interface ITrain
{
    public Speed Speed { get; }

    public Mass Mass { get; }

    public Force MaxAllowableForce { get; }

    public ForceCheckerResult TryCalculateSpeed(Force force, Time time);
}
