using Itmo.ObjectOrientedProgramming.Lab3.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Domain.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver, IDisposable
{
    private readonly StreamWriter _stream;

    public FileDisplayDriver(Color color, string path)
    {
        Color = color;
        _stream = new StreamWriter(File.Open(path, FileMode.OpenOrCreate, FileAccess.Write));
    }

    public Color Color { get; private set; }

    public void PrintMessage(string message)
    {
        ClearDisplay();
        _stream.WriteLine(Modify(message));
    }

    public void ClearDisplay()
    {
        _stream.Flush();
    }

    public void SetColor(Color color)
    {
        Color = color;
    }

    public void Dispose()
    {
        _stream.Dispose();
    }

    private string Modify(string message)
    {
        return Crayon.Output.Rgb(Color.R, Color.G, Color.B).Text(message);
    }
}