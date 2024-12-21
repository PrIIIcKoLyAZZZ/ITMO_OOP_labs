using Itmo.ObjectOrientedProgramming.Lab4.Domain.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Domain.FileSystem;

public interface IFileSystem
{
    public ExecutionResult MoveFile(string sourcePath, string destinationPath);

    public ExecutionResult CopyFile(string sourcePath, string destinationPath);

    public ExecutionResult DeleteFile(string path);

    public ExecutionResult RenameFile(string path, string newName);

    public ExecutionResult ShowFile(string path);

    public IList<string> GetFiles(string path);

    public IList<string> GetDirectories(string path);

    public Name GetDirectoryName(string path);

    public string MergePaths(string path, string newPath);
}