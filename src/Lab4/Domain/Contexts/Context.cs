using Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.Contexts;

public class Context
{
    public IFileSystem? FileSystem { get; set; }

    public string Path { get; set; } = string.Empty;
}