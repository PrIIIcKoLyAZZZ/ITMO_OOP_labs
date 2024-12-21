namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.FinalPoints.Messengers;

public class Messenger : IMessenger
{
    public string PrintMessage(string message)
    {
        return $"Messenger: {message}";
    }
}