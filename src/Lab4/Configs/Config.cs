using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Configs;

public class Config
{
    public string FolderSymbol { get; set; } = "📁";

    public string FileSymbol { get; set; } = "📄";

    public char IndentSymbol { get; set; } = '\t';

    public Depth DefaultDepth { get; set; } = new Depth(1);
}